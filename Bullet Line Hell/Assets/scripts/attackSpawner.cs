using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/*
* lookup would be any position pointing away from the player position
*                      
*                      ^
*                      |
*
*          <-    playerPosition    ->
*
* the enemyData struct is meant so each array in our list would contain more data in a single instance of this enemyData struct
* todo: add more variables to customize the aim of our enemy
*/
public class attackSpawner : MonoBehaviour{

    private struct enemyData{
        public int arrayPosition;
        public float x;
        public float y;
        public float z;
        public Vector3 lookUp;
    }

    [SerializeField] private GameObject attackPath;
    [SerializeField] private GameObject player;
    public int attackAmount = 1;
    public int TimeBetweenAttack = 5;
    public int spawnBuffer = 2;

    private float spawnBufferCountDown = 0;
    private float attackCountDown = 0;
    private int amountEnemyPerAttackTime = 1;

    private void Awake(){
        spawnBufferCountDown = spawnBuffer;
    }

    void Update(){
        List<enemyData> enemyDataList = new List<enemyData>();

        if (spawnBufferCountDown > 0)
        {
            spawnBufferCountDown -= Time.deltaTime;
        }else if (attackAmount > 0 && attackCountDown <= 0)
        {
            //define the amount of enemies we will like to spawn
            amountEnemyPerAttackTime = randomAmountOfEnemies(1, 6);

            //TODO: check later if this creates any overhead or something dumb
            //defines defines the enemy position and where the laser would aim
            for (int i = 0; i < amountEnemyPerAttackTime; i++){
                enemyDataList.Add(new enemyData());
                enemyDataList[i] = enemyPositionAndRotation(enemyDataList[i],i);
                enemyCreation(enemyDataList[i]); //spawning of the laser and the enemy
            }

            attackAmount--;
            attackCountDown = TimeBetweenAttack;
        }
        else if (attackCountDown > 0)
        {
            attackCountDown -= Time.deltaTime;
        }
    }

    public void endAttack(){
        attackAmount = 0;
    }

    private int randomAmountOfEnemies(int min, int max){
        return UnityEngine.Random.Range(min, (max + 1));
    }

    //this is to define the enemy position and rotation
    private enemyData enemyPositionAndRotation(enemyData enemy, int arrayPosition){
        float[] position = new float[2];
        Vector3 playerPosition = Vector3.zero;
        Vector3 enemyPosition;

        enemy.arrayPosition = arrayPosition;
        definePositionValues(position);
        enemy.x = position[SPOT.X_POSITION_VALUE];
        enemy.y = position[SPOT.Y_POSITION_VALUE];
        enemy.z = 0f;
        playerPosition = player.transform.position;
        enemyPosition = new Vector3(enemy.x, enemy.y);

        //defines a case on player position or near player position
        if (enemy.arrayPosition == 0)
        {
            enemy.lookUp = enemyPosition - playerPosition;
        }
        else
        {
            float nearPlayerPositionX = UnityEngine.Random.Range((playerPosition.x - 1f), (playerPosition.x + 1f));
            float nearPlayerPositionY = UnityEngine.Random.Range((playerPosition.y - 1f), (playerPosition.y + 1f));
            Vector3 nearPlayerPosition = new Vector3(nearPlayerPositionX, nearPlayerPositionY);
            enemy.lookUp = enemyPosition - nearPlayerPosition;
        }

        return enemy;
    }

    //creates the enemy
    private void enemyCreation(enemyData enemy){
        quaternion rotation = quaternion.LookRotation(Vector3.back, enemy.lookUp);
        Vector3 enemyPosition = new Vector3(enemy.x, enemy.y, enemy.z);
        Instantiate(attackPath, enemyPosition, rotation);
    }

    private static void definePositionValues(float[] position){

        bool spawnOnSide = UnityEngine.Random.value < 0.5f;
        bool positiveSide = UnityEngine.Random.value < 0.5f;

        if (spawnOnSide && positiveSide)
        {
            position[SPOT.X_POSITION_VALUE] = 8f;
            position[SPOT.Y_POSITION_VALUE] = UnityEngine.Random.Range(-1f, 1f) * 4.5f;
        }else if (spawnOnSide && !positiveSide)
        {
            position[SPOT.X_POSITION_VALUE] = -8f;
            position[SPOT.Y_POSITION_VALUE] = UnityEngine.Random.Range(-1f, 1f) * 4.5f;
        }else if (!spawnOnSide && positiveSide)
        {
            position[SPOT.X_POSITION_VALUE] = UnityEngine.Random.Range(-1f, 1f) * 8f;
            position[SPOT.Y_POSITION_VALUE] = 4.5f;
        }
        else if(!spawnOnSide && !positiveSide)
        {
            position[SPOT.X_POSITION_VALUE] = UnityEngine.Random.Range(-1f, 1f) * 8f;
            position[SPOT.Y_POSITION_VALUE] = -4.5f;
        }
        
    }
}

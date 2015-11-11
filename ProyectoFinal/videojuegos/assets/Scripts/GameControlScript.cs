using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;

public class GameControlScript : MonoBehaviour {

	float timeRemaining = 15;   //Tiempo Inicial
	float timeExtension = 2f;   //Tiempo para extender
	float timeDeduction = 2f;   //Tiempo para reducir
	float totalTimeElapsed = 0; //Se enviara por JSON
	public float totalJumps = 0; //Se enviara por JSON
	public float totalCoins = 0; //Se enviara por JSON
	public float secondsToWin = 30;

	float score=0f;      //total
	public string mainMenuScene;
	public string gameScene;
	public string winScene;
	public bool isGameOver = false; 


	private bool enviadoJson = false;

	void Start(){
		Time.timeScale = 1; 
	}

	void OnGUI()
	{
		//si estamos jugando desplegamos el puntaje y tiempo
		if(!isGameOver)    
		{
			GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"TIEMPO: "+((int)timeRemaining).ToString());
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 10, Screen.width/6, Screen.height/6), "PUNTOS: "+((int)score).ToString());

			if(totalTimeElapsed >= secondsToWin){
				Application.LoadLevel(winScene);
			}
		}
		//de lo contrario mostramos el game over
		else
		{
			Time.timeScale = 0; //paramos el mundo
			
			//mostramos el puntaje final
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "FIN DEL JUEGO\nSU PUNTAJE: "+(int)score);
			
			//al hacer click se reinicia el juego
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "REINICIAR")){
				//Application.LoadLevel(Application.loadedLevel);
				Application.LoadLevel(gameScene);
			}
			
			//Cargar el menu principal
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MENU PRINCIPAL")){
				Application.LoadLevel(mainMenuScene);
			}
			
			//salir
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "SALIR")){
				Application.Quit();
			}
			/*
			//enviarJSON(200f,300f,400f);
			if(!enviadoJson){
				enviarJSON(totalTimeElapsed, totalJumps, totalCoins);
				enviadoJson = true;
			}
			*/
		}
	}

	void Update () { 
		if(isGameOver)     //si hay gameover
			return;      //salir
		
		totalTimeElapsed += Time.deltaTime; 
		score = totalTimeElapsed*100;  //calcular el puntaje basado en el total de tiempo
		timeRemaining -= Time.deltaTime; //restar el tiempo que queda por uno cada
		if(timeRemaining <= 0){
			isGameOver = true;    // poner gameover en true si se ha acabado el tiempo
		}
	} 

	public void PowerupCollected()
	{
		timeRemaining += timeExtension;   //sumar tiempo
	}
	
	public void AlcoholCollected()
	{
		timeRemaining -= timeDeduction;   // restar tiempo
	}

	private void enviarJSON(float tiempo, float saltos, float monedas){
		Debug.Log("Inicio Enviando JSON");
		
		//var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.0.100:60000/credidata/test/AstroCoinIn.php");
		var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://190.157.34.22:60000/credidata/test/AstroCoinIn.php");
		httpWebRequest.ContentType = "text/json";
		httpWebRequest.Method = "POST";
		
		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			/*
			string json = "{\"user\":\"test\"," +
				"\"password\":\"bla\"}";
			*/
			/*
			string json = "{\"tiempo\":\"10\"," +
				"\"saltos\":\"30\"}";
			*/
			/*
			string json = "{"+
				"\"tiempo\":\"10\"," +
				"\"saltos\":\"20\"," +
				"\"monedas\":\"30\"}";
			*/
			
			string json = "{"+
				"\"tiempo\":\""+tiempo+"\"," +
					"\"saltos\":\""+saltos+"\"," +
					"\"monedas\":\""+monedas+"\"}";
			
			/*
			string json = "{" +
				"\"tiempo\":\"10\"," +
				"\"saltos\":\"30\","+
				"\"monedas\":\"50\","+
				"}";
			*/
			streamWriter.Write(json);
			streamWriter.Flush();
			streamWriter.Close();
		}
		
		var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
		{
			var result = streamReader.ReadToEnd();
			Debug.Log("Resultado: " + result);
		}
		
		Debug.Log("Fin Enviando JSON");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;

public class WeatherManager : MonoBehaviour
{
    
    [Serializable]
    public struct CoordInfo
    {
        public float lon;
        public float lat;
    }
    [Serializable]
    public struct WeatherDetails
    {
        public int id;
        public string main;
        public string description;
    }
    [Serializable]
    public struct WeatherAmbient
    {
        public float temp;
    }
    [Serializable]
    public struct WeatherWind
    {
        public float speed;
        public float deg;
    }
    [Serializable]
    public struct CloudsInfo
    {
        public int all;
    }
    [Serializable]
    public struct WeatherInfo
    {
        public int id;
        public string name;
        public string message;
        public int cod;
        public List<WeatherDetails> weather;
        public WeatherAmbient main;
        public WeatherWind wind;
        public CloudsInfo clouds;
        public CoordInfo coord;
    }

    public string apiKey = "cf6ba7777e4a24bad15c138a2c8b23ac";

    [Header("Title")]
    public InputField cityInput;

    [Header("Info")]
    public Text coordText;
    public Text weatherText;
    public Text tempText;
    public Text windText;
    public Text cloudsText;

    public GameObject weatherObj;
    public Text errorText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GetWeather", cityInput.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetWeather(string city){
        if(city == "")
            yield break;

        string uri = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", city, apiKey);
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            WeatherInfo json = JsonConvert.DeserializeObject<WeatherInfo>(webRequest.downloadHandler.text);
            
            if(json.cod == 404){
                weatherObj.SetActive(false);
                errorText.gameObject.SetActive(true);
                errorText.text = json.message;
                yield break;
            }

            weatherObj.SetActive(true);
            errorText.gameObject.SetActive(false);

            coordText.text = string.Format("lon: {0},  lat: {1}", json.coord.lon, json.coord.lat);
            if(json.weather.Count > 0)
                weatherText.text = string.Format("{0} ({1})", json.weather[0].main, json.weather[0].description);
            tempText.text = json.main.temp.ToString();
            windText.text = string.Format("speed: {0} / deg: {1}", json.wind.speed, json.wind.deg);
            cloudsText.text = json.clouds.all.ToString();
        }
    }

    public void OnCityInputChange(){
        StartCoroutine("GetWeather", cityInput.text);
    }
}

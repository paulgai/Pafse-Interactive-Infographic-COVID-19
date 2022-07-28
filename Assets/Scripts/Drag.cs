using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class Drag : MonoBehaviour, IDragHandler, IPointerClickHandler, IBeginDragHandler, IEndDragHandler
{
    public bool isCorrect = true;

    public bool isDragEnebled = true;

    private Vector3 dragOffset;

    private float ThresholdDistance = 0.5f;

    private float minDistance = 100f;

    private Vector3 StartPos;

    private GameObject NearestPlace;

    public GameObject GV;

    void Start()
    {
        StartPos = GetComponent<RectTransform>().localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDragEnebled) 
        {
            Vector3 worldPoint;
            RectTransformUtility
                .ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(),
                eventData.position,
                eventData.pressEventCamera,
                out worldPoint);
            dragOffset = GetComponent<RectTransform>().position - worldPoint;
            GetComponent<Canvas>().sortingOrder = -1;
            //Debug.Log("StartPos=" + StartPos);
        }
        
    }

    private void CalculateMinDistance() 
    {
        GameObject[] places = GameObject.FindGameObjectsWithTag("Place");
        float[] distances = new float[places.Length];
        for (int i = 0; i < distances.Length; i++) 
        {
            places[i].transform.GetChild(0).gameObject.SetActive(false);
            distances[i] = Vector3.Distance(GetComponent<RectTransform>().position, 
                places[i].GetComponent<RectTransform>().position);
        }

        minDistance = distances.Min();
        int minIndex = System.Array.IndexOf(distances, minDistance);
        NearestPlace = places[minIndex];
        NearestPlace.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragEnebled)
        {
            GetComponent<Canvas>().sortingOrder = -2;
            CalculateMinDistance();
            bool isHappy = NearestPlace.GetComponent<Place>().isHappy;
            bool isOccupied = NearestPlace.GetComponent<Place>().isOccupied;
            if (minDistance < ThresholdDistance && isHappy == isCorrect && !isOccupied)
            {
                GetComponent<RectTransform>().position = NearestPlace.GetComponent<RectTransform>().position;
                NearestPlace.GetComponent<Place>().isOccupied = true;
                isDragEnebled = false;
                GV.GetComponent<GV>().Correct += 1;
            }
            else
            {
                GoToStart();
            }
        }
            
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragEnebled)
        {
            SetDraggedPosition (eventData);
            //CalculateMinDistance();
            //Debug.Log("minDistance=" + minDistance);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        Vector3 worldPoint;
        if (
            RectTransformUtility
                .ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(
                ),
                data.position,
                data.pressEventCamera,
                out worldPoint)
        )
        {
            GetComponent<RectTransform>().position = worldPoint + dragOffset;
        }
    }

    private void GoToStart()
    {
        Tween myTween =
            GetComponent<RectTransform>().DOLocalMove(StartPos, 0.5f);
        myTween.SetEase(Ease.OutSine);
    }
}

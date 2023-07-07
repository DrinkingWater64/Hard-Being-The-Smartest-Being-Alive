using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySystem : MonoBehaviour
{
    [SerializeField]
    private List<Camera> cameras = new List<Camera>();
    [SerializeField]
    private Camera _mainCamera;

    [SerializeField] private Rect _rect = new Rect(0, 0, .5f, .5f);
    [SerializeField] private Rect rect1 = new Rect(.5f, 0, .5f, .5f);
    [SerializeField] private Rect rect2 = new Rect(0, .5f, .5f, .5f);
    [SerializeField] private Rect rect3 = new Rect(.5f, .5f, .5f, .5f);




    // Start is called before the first frame update
    void Start()
    {
        if (cameras.Count == 0)
        {
            cameras.Add(_mainCamera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cameras.Count == 1)
        {
            SingleCamView();
        }else if (cameras.Count == 2)
        {
            SingleSplitVIew();
        }else if(cameras.Count == 3)
        {
            DoubleSplitViewForThree();
        }else if(cameras.Count == 4)
        {
            DoubleSplitViewForFour();
        }

    }

    private void DoubleSplitViewForFour()
    {
          cameras[0].rect = _rect;
        cameras[1].rect = rect1;
        cameras[2].rect = rect2;
        cameras[3].rect = rect3;

    }

    private void DoubleSplitViewForThree()
    {
        cameras[0].rect = _rect;
        cameras[1].rect = rect1;
        cameras[2].rect = rect2;

    }

    private void SingleSplitVIew()
    {
        cameras[0].rect = new Rect(0, 0, .5f, 1f);
        cameras[1].rect = new Rect(.5f, 0, .5f, 1f);
    }

    private void SingleCamView()
    {
        _mainCamera.rect = new Rect(0,0,1,1);
    }
    
    public void AddToCameraList(Camera cam)
    {
        cameras.Add(cam);
    }
    
}

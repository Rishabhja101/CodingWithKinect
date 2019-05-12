using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectAvatarController : MonoBehaviour
{
    private GameObject Avatar;

    private List<GameObject> Bodies;

    private string[] joints = new string[] 
    {
        "SpineBase",
        "SpineMid",
        "Neck",
        "Head",
        "ShoulderLeft",
        "ElbowLeft",
        "WristLeft",
        "HandLeft",
        "ShoulderRight",
        "ElbowRight",
        "WristRight",
        "HandRight",
        "HipLeft",
        "KneeLeft",
        "AnkleLeft",
        "FootLeft",
        "HipRight",
        "KneeRight",
        "AnkleRight",
        "FootRight",
        "SpineShoulder",
        "HandTipLeft",
        "ThumbLeft",
        "HandTipRight",
        "ThumbRight"
    };


    // Start is called before the first frame update
    void Start()
    {
        Bodies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBodiesList();
        UpdateSkeleton(Bodies[0]);
    }

    private void UpdateSkeleton(GameObject Skeleton)
    {
        Avatar = GameObject.Find("MaleCustomize");
        for (int i = 0; i < Avatar.transform.GetChild(1).transform.GetChild(0).transform.childCount; i++)
        {
            print(Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).name);
        }
        
        Dictionary<string, Transform> avatarMap = new Dictionary<string, Transform>()
        {
            {"SpineBase",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2) },
            {"SpineMid",        Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0) },
            {"Neck",            Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1) },
            {"Head",            Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0) },
            {"ShoulderLeft",    Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"ElbowLeft",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"WristLeft",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"HandLeft",        Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"ShoulderRight",   Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2) },
            {"ElbowRight",      Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0) },
            {"WristRight",      Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"HandRight",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"HipLeft",         Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0) },
            {"KneeLeft",        Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"AnkleLeft",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"FootLeft",        Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"HipRight",        Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1) },
            {"KneeRight",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0) },
            {"AnkleRight",      Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).transform.GetChild(0) },
            {"FootRight",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0) },
            {"SpineShoulder",   Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0) },
            {"HandTipLeft",     Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1) },
            {"ThumbLeft",       Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(4) },
            {"HandTipRight",    Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1) },
            {"ThumbRight",      Avatar.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(4) }
        };

        Dictionary<string, Transform> boneMap = new Dictionary<string, Transform>()
        {
            {"SpineBase",       Skeleton.transform.GetChild(0) },
            {"SpineMid",        Skeleton.transform.GetChild(1) },
            {"Neck",            Skeleton.transform.GetChild(2) },
            {"Head",            Skeleton.transform.GetChild(3) },
            {"ShoulderLeft",    Skeleton.transform.GetChild(4) },
            {"ElbowLeft",       Skeleton.transform.GetChild(5) },
            {"WristLeft",       Skeleton.transform.GetChild(6) },
            {"HandLeft",        Skeleton.transform.GetChild(7) },
            {"ShoulderRight",   Skeleton.transform.GetChild(8) },
            {"ElbowRight",      Skeleton.transform.GetChild(9) },
            {"WristRight",      Skeleton.transform.GetChild(10) },
            {"HandRight",       Skeleton.transform.GetChild(11) },
            {"HipLeft",         Skeleton.transform.GetChild(12) },
            {"KneeLeft",        Skeleton.transform.GetChild(13) },
            {"AnkleLeft",       Skeleton.transform.GetChild(14) },
            {"FootLeft",        Skeleton.transform.GetChild(15) },
            {"HipRight",        Skeleton.transform.GetChild(16) },
            {"KneeRight",       Skeleton.transform.GetChild(17) },
            {"AnkleRight",      Skeleton.transform.GetChild(18) },
            {"FootRight",       Skeleton.transform.GetChild(19) },
            {"SpineShoulder",   Skeleton.transform.GetChild(20) },
            {"HandTipLeft",     Skeleton.transform.GetChild(21) },
            {"ThumbLeft",       Skeleton.transform.GetChild(22) },
            {"HandTipRight",    Skeleton.transform.GetChild(23) },
            {"ThumbRight",      Skeleton.transform.GetChild(24) }
        };
        
        foreach(string joint in joints)
        {
            avatarMap[joint].position = boneMap[joint].position;
        }

    }

    private void UpdateBodiesList()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("skeleton");
        List<GameObject> obs = new List<GameObject>();
        foreach(GameObject ob in objects)
        {
            if (!Bodies.Contains(ob))
            {
                Bodies.Add(ob);
            }
            obs.Add(ob);
        }
        foreach(GameObject ob in Bodies)
        {
            if (!obs.Contains(ob))
            {
                Bodies.Add(ob);
            }
        }
    }
}

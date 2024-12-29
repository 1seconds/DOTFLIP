using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectData : ScriptableObject
{
    public string id;
    public ObjectType type;
}

public enum ObjectType {
    None = 0,
    Block = 1
}

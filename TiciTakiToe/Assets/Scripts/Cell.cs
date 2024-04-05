using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    public Field type;

    public int neighbours;

    public Cell()
    {
        type = Field.Undef;
        neighbours = 0;
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID
{
    private Guid _guid;
    private IDType _type;
    public enum IDType { Annotation, Target }


    public ID(IDType type)
    {
        _guid = Guid.NewGuid();
        _type = type;
    }

    public ID(IDType type, Guid guid)
    {
        _guid = guid;
        _type = type;
    }

    public ID(string idString)
    {
        var splitString = idString.Split(':');

        var typeString = splitString[0];
        if (typeString == "annotation:")
            _type = IDType.Annotation;
        if (typeString == "target:")
            _type = IDType.Target;

        var guidString = splitString[1];
        _guid = new Guid(guidString);
    }

    public override string ToString()
    {
        string prefix;

        if (_type == IDType.Annotation)
            prefix = "annotation:";
        else
            prefix = "target:";

        return prefix + _guid.ToString();
    }
}
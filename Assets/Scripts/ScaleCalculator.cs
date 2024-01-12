using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCalculator
{
    float maxScale = 4f;
    float minScale = 1.2f;
    float obstacleDamageValue = 0.8f;

    public Vector3 CalculatePlayerHeadSize(GateType gateType, int gateValue, Transform headTransform)
    {
        float changeSize = gateValue / 100f;

        float newXScale = 0;
        float newYScale = 0;
        float newZScale = 0;

        switch (gateType)
        {
            case GateType.fatterType:
                newXScale = headTransform.localScale.x + changeSize;
                newYScale = headTransform.localScale.y + changeSize;
                newZScale = headTransform.localScale.z;

                if(newXScale > maxScale)
                {
                    newXScale = maxScale;
                }
                if(newYScale > maxScale)
                {
                    newYScale = maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.thinnerType:
                newXScale = headTransform.localScale.x - changeSize;
                newYScale = headTransform.localScale.y - changeSize;
                newZScale = headTransform.localScale.z;

                if(newXScale < minScale)
                {
                    newXScale = minScale;
                }
                if (newYScale < minScale)
                {
                    newYScale = minScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.tallerType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z + changeSize;

                if(newZScale > maxScale)
                {
                    newZScale= maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.shorterType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z - changeSize;

                if(newZScale < minScale)
                {
                    newZScale = minScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);
        }

        return new Vector3(newXScale, newYScale, newZScale);
    }

    public Vector3 DecreasePlayerHeadSize(Transform playerTransform)
    {
        float newXScale = playerTransform.localScale.x - obstacleDamageValue;
        float newYScale = playerTransform.localScale.y - obstacleDamageValue;
        float newZScale = playerTransform.localScale.z - obstacleDamageValue;

        if(newXScale < minScale)
        {
            newXScale = minScale;
        }
        if(newYScale < minScale)
        {
            newYScale = minScale;
        }
        if (newZScale < minScale)
        {
            newZScale = minScale;
        }

        return new Vector3(newXScale, newYScale, newZScale);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour
{
    public Transform characterTransform;
    public Transform clonesTransform;
    List<Transform> clonesTransforms;
    int activeCloneIndex;

    void OnEnable() // called when enabled
    {
        Debug.Log("enabling switchmode");

        // get clones transforms
        clonesTransforms = new List<Transform>();
        foreach (Transform t in clonesTransform)
            clonesTransforms.Add(t);

        if(clonesTransforms.Count==0)
            return;
        
        SetActiveCharacterArrow(false);
        activeCloneIndex = 0;
        SetActiveCloneArrow(activeCloneIndex, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(clonesTransforms.Count==0)
            ExitSwitchMode();

        int newActiveCloneIndex = activeCloneIndex;
        if(Input.GetKeyDown(KeyCode.A))
            newActiveCloneIndex = (activeCloneIndex + clonesTransforms.Count - 1) % clonesTransforms.Count;
        else if(Input.GetKeyDown(KeyCode.D))
            newActiveCloneIndex = (activeCloneIndex + 1) % clonesTransforms.Count;

        if (newActiveCloneIndex != activeCloneIndex)
        {
            SetActiveCloneArrow(activeCloneIndex, false);
            SetActiveCloneArrow(newActiveCloneIndex, true);
            activeCloneIndex = newActiveCloneIndex;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchToClone(activeCloneIndex);
            // TODO: update UI text
            ExitSwitchMode();
        }
    }

    private void ExitSwitchMode()
    {
        Debug.Log("disabling switchmode");
        GetComponent<PlayerMove>().enabled = true;
        this.enabled = false;
    }

    private void SwitchToClone(int cloneIndex)
    {
        Debug.Log("Switching to clone");
        SetActiveCloneArrow(cloneIndex, false);

        var activeCloneTransform = clonesTransforms[cloneIndex];
        var tmp = characterTransform.position;
        characterTransform.position = activeCloneTransform.position;
        activeCloneTransform.position = tmp;

        FixFacingDirections(activeCloneTransform);
        SetActiveCharacterArrow(true);
    }

    private void FixFacingDirections(Transform activeCloneTransform)
    {
        var characterSR = characterTransform.GetComponent<SpriteRenderer>();
        var cloneSR = activeCloneTransform.GetComponent<SpriteRenderer>();

        if(characterSR.flipX != cloneSR.flipX)
        {
            characterSR.flipX = !characterSR.flipX;
            cloneSR.flipX = !cloneSR.flipX;
        }
    }

    void SetActiveCloneArrow(int cloneIndex, bool active)
    {
        var cloneArrow = clonesTransforms[cloneIndex].Find("arrow").gameObject;
        Debug.Assert(cloneArrow != null);
        cloneArrow.SetActive(active);
    }
    void SetActiveCharacterArrow(bool active)
    {
        var characterArrow = characterTransform.Find("arrow").gameObject;
        Debug.Assert(characterArrow != null);
        characterArrow.SetActive(active);
    }
}

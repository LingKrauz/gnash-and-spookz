using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Collectibles : MonoBehaviour
{
    private CollectibleUI collectibleUI;
    private GameManager gameManager;
    public AudioController audioCon;

    private PortraitCutscene Pcutscene;

    private CollectableItemSet collectableItemSet;
    private UniqueID uniqueID;

    public Animator pAnim;

    public void Awake()
    {
        collectibleUI = GameObject.Find("HUD").GetComponent<CollectibleUI>();
        gameManager = FindObjectOfType<GameManager>();
        audioCon = GameObject.Find("AudioSource").GetComponent<AudioController>();
        pAnim = FindObjectOfType<PlayerAnimController>().GetComponent<Animator>();
    }

    public void Start()
    {
        uniqueID = GetComponent<UniqueID>();
        collectableItemSet = FindObjectOfType<CollectableItemSet>();

        if (collectableItemSet.CollectedItems.Contains(uniqueID.ID))
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.gameObject.tag == "PortraitPiece")
            {
                pAnim.SetBool("doCelebrate", true);
                PlayerPrefs.SetInt("CurrentPortraitPiece", PlayerPrefs.GetInt("CurrentPortraitPiece") + 1);
                Pcutscene = FindObjectOfType<PortraitCutscene>();
                Pcutscene.PlayCutscene();
                gameManager.CollectedPortraitPiece();
                collectableItemSet.CollectedItems.Add(uniqueID.ID);
                collectableItemSet.Save();
            }

            else if (this.gameObject.tag == "Wisp")
            {
                PlayerPrefs.SetInt("CurrentWisps", PlayerPrefs.GetInt("CurrentWisps") + 1);
                collectableItemSet.CollectedItems.Add(uniqueID.ID);
                collectableItemSet.Save();
                gameManager.CollectedWisp();
            }

            collectibleUI.UpdateCollectibles(gameObject.tag);
            Destroy(gameObject);
            audioCon.PlayPickupAudio(gameObject.tag);
        }
    }
}

using UnityEngine;
using System.Collections;

public class toggleMenuAnimation : MonoBehaviour
{
  private Animator anim;
 
  private bool uiSubMenuIsVisible = false;

  public void toggleSubMenu()
  {

    anim = GetComponent<Animator>();

    anim.SetBool("exitDefault", true);

    if (uiSubMenuIsVisible)
    {
      anim.SetBool("isOpen", true);
    }
    else
    {
      anim.SetBool("isOpen", false);
    }

    uiSubMenuIsVisible = !uiSubMenuIsVisible;
  }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetUserConfig : MonoBehaviour
{
    public Sprite[] posts;
    public Text[] textFields;
    public User userConfig;
    public Image postImage;

    private void Update()
    {
        if (userConfig != null)
        {
            if (userConfig.authorized)
            {
                postImage.sprite = posts[userConfig.post];
                textFields[0].text = userConfig.firstName;
                textFields[1].text = userConfig.lastName;
            }
        }
    }
}

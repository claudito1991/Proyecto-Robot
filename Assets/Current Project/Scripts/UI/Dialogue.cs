using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    IEnumerator TypeLine()
    {
        // el foreach recorre los caracteres.  lines index va tomando las lineas del string y pasandolas a caracteres con el char array
        foreach (char c in lines[index].ToCharArray())
        {
            // aca digo que el texto del componente de texto se vaya escribiendo un caracter por vez
            textComponent.text += c;
            //acá seteo la velocidad a la cual se va a mostrar ese texto
            yield return new WaitForSeconds(textSpeed);


        }
    }

    void NextLine()
    {
        if (index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

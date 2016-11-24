using UnityEngine; using UnityEngine.UI;
using System.Collections;

public class CreditsContent : MonoBehaviour {

    public Text credits_text;

    string writers_text;
    string artist_text;
    string implementation_text;

    void Start ()
    {
        credits_text.text = writers_text;
    }

    void SetupWritersCreds ()
    {
        writers_text = " WRITERS ";

    }
}
/*Writers

Max Carlberg
Fredrik Bredberg
Zelda Karttunen
Martin Danielsson

Art 

Kajsa Lundquist
Charlie Raud
Matilda Hollander
Marcel Fontes
Kevin Fransson
Natti Nattsson
Wictor Nilsson

Implementation

Ludvig Emtås
Hektor Andreasson
Alexander Wimmerstedt
Axel Stenkrona
Azul Romo Flores



Music


....

    */
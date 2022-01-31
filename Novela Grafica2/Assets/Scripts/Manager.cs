using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using TMPro;



public enum Escenarios
{
   CASA=0,
   CUARTO=1,
   VENTANA=2,
   CAMA=3,
   CANTIMPLORA=4,
   CAMINO=5,
   ESPADA=6,
   CAMA1=7,
   CAMA2=8,
   CETRO=9,
   CLARO=10,
   CIELOCLARO=11,
   MATARDEMONIO=12,
   CUARTODEMONIO=13,
   RIO=14,
   VENTANA2=15,
   VENTANA3=16,
   ATACARESTRELLA=17,
   RIO1=18,
   CABALLERAPECES=19,
   CABALLERADEMONIO=20,
   CASA1=21
};


public enum Estados
{
    SHOW = 0,
    HIDE = 1,
    NOTHING=2,
};

public enum SentimientosNiñoLetra
{
    NORMAL = 0,
    MIEDO = 1,
    EXTRAÑO=2

};

public enum EstadosFisicos
{
    OVEJITA_NORMAL = 0,
    OVEJITA_LLORANDO = 1,
    OVEJITA_ASUSTADA=2,
    OVEJITA_CABALLERA_DEMONIO=3,  
    OVEJITA_CABALLERA_PESCADO=4,

    PADRES_NORMAL=5,

    ESTRELLA_NORMAL=6,
    ESTRELLA_ASUSTADA=7,
    ESTRELLA_MALVADA=8,

    DEMONIO_NORMAL=9,
    DEMONIO_ASUSTADO=10,

    MAGO_NORMAL=11,

    PEZ_NORMAL=12,
    PEZ_AGONIZANTE=13


};



public class Manager : MonoBehaviour
{

//Pausa
bool Pausa=false;
    //NUMERO DIALOGO
    static public  int NumDialog=0;


     bool UnaVez=false;
    //BOTTONES
public Button Izquierda;
public Button Derecha;
public Button A_Izquierda;
public Button A_Derecha;
public Button B_Izquierda;
public Button B_Derecha;
public Button C_Izquierda;
public Button C_Derecha;
public Button D_Izquierda;
public Button D_Derecha;
public Button E_Izquierda;
public Button E_Derecha;
public Button F_Izquierda;
public Button F_Derecha;
public Button G_Izquierda;
public Button G_Derecha;
public Button H_Izquierda;
public Button H_Derecha;








    
    [Range(0, 1)]
    
    ////TRASPARENCIA DE LAS IMAGENES
    public float Transparencia = 0, transitionSpeed = 1;
    public SpriteRenderer spriteRenderer;
    
    public SpriteRenderer escenariosSpriteRenderer;


   
    //ENUMS
    public Estados E_estados;
    public SentimientosNiñoLetra E_Sentir;
    public EstadosFisicos E_estadosFisicos;

    public Escenarios E_escenarios;



    public GameObject   dialogo;

    //TEXTO
    public TMP_Text txt_NombreDialogo;
    public TMP_Text txt_Dialogo;
    Mesh TextMesh;
    Vector3[] vertices;



    [Header("Estados Fisicos")]
    
  ////////////////////////////////////
/////////      SPRITES     ////////////
  ////////////////////////////////////
    ///OVEJITA
    public Sprite Ovejita_Normal;
    public Sprite Ovejita_Llorando;
    public Sprite Ovejita_Asustada;
    public Sprite Ovejita_Caballera_Demonio;
    public Sprite Ovejita_Caballera_Pescados;    
    /////////////////////////////////////////
    ///PADRES
    public Sprite Padres_Normal;
    /////////////////////////////////////////   
    ///ESTRELLA
    public Sprite Estrella_Normal;
    public Sprite Estrella_Asustada;
    public Sprite Estrella_Malvada;
    /////////////////////////////////////////
    ///DEMONIO
    public Sprite Demonio_Normal;
    public Sprite Demonio_Asustado;
    ////////////////////////////////////////
    ///MAGO
    public Sprite Mago_Normal;
    ////////////////////////////////////////
    ///PEZ
    public Sprite Pez_Normal;
    public Sprite Pez_Agonizante;

////////////////////////////////////////////////////
    public Sprite Escenario_Cocina;

     public Sprite Escenario_CuartoThomas;

    public Sprite Escenario_Sala;
   
    public Expresiones_Fisicas[] expresiones_Fisicas;
    public Clase_escenarios[] escenarios;
  
  



    [Header("config de Teclado")]
    public KeyCode teclaSiguiente;
    public KeyCode teclaSiguiente2;


    //Tipo de letra y lo que dira el personaje como también el personaje
    [Header("Nombre")]

    public string Nombre;
    [Header("Tipo de Letra")]
    public TMP_FontAsset fontGeneral;
    [Header("Dialogos")]
    public Talking[] dialogoEnsayo;
void ActivarBotones(Button _Izquierda, Button _Derecha){
      _Izquierda.gameObject.SetActive(true);
      _Derecha.gameObject.SetActive(true);
}
void DesactivarBotones(){
        Izquierda.gameObject.SetActive(false);
        Derecha.gameObject.SetActive(false);
        A_Izquierda.gameObject.SetActive(false);
        A_Derecha.gameObject.SetActive(false);
        B_Izquierda.gameObject.SetActive(false);
        B_Derecha.gameObject.SetActive(false);
        C_Izquierda.gameObject.SetActive(false);
        C_Derecha.gameObject.SetActive(false);
        D_Izquierda.gameObject.SetActive(false);
        D_Derecha.gameObject.SetActive(false);
        E_Izquierda.gameObject.SetActive(false);
        E_Derecha.gameObject.SetActive(false);
        F_Izquierda.gameObject.SetActive(false);
        F_Derecha.gameObject.SetActive(false);
        G_Izquierda.gameObject.SetActive(false);
        G_Derecha.gameObject.SetActive(false);
        H_Izquierda.gameObject.SetActive(false);
        H_Derecha.gameObject.SetActive(false);    
}

    void Start()
    {  
        

 //Izquierda.image.color=new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Transparencia);       
        //LLenar botones
        CapturarBotones();
        DesactivarBotones();
        ///llenar lA IMAGENES DEL NIÑO
        EstadosImagen();   
        EstadoEscenario();

        //CANCION
        SoundManager.PlaySound("lovesong");
        //Nombre quien esta hablando
        
        //Estado de la imagen
        E_estados = Estados.NOTHING;
        //Cargado de Guion de la novela
        InicioGame();
        //Correr Guion de la novela
        Empezar_Conversacion();
    }

      
   
    void Update()
    {

    ////Estados del Personaje--------- IMAGEN
        if (E_estadosFisicos.Equals(EstadosFisicos.OVEJITA_NORMAL))
            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = expresiones_Fisicas[0].ImagenPersonaje;

        if (E_estadosFisicos.Equals(EstadosFisicos.OVEJITA_LLORANDO))
            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = expresiones_Fisicas[1].ImagenPersonaje;

        if (E_estadosFisicos.Equals(EstadosFisicos.OVEJITA_ASUSTADA))
            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = expresiones_Fisicas[2].ImagenPersonaje;
            
        if (E_estadosFisicos.Equals(EstadosFisicos.OVEJITA_CABALLERA_DEMONIO))
            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = expresiones_Fisicas[3].ImagenPersonaje;
                        
        if (E_estadosFisicos.Equals(EstadosFisicos.OVEJITA_CABALLERA_PESCADO))
            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = expresiones_Fisicas[4].ImagenPersonaje;

                            
        if (E_estadosFisicos.Equals(EstadosFisicos.PADRES_NORMAL))
            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = expresiones_Fisicas[5].ImagenPersonaje;

/////////
         if (E_escenarios.Equals(Escenarios.CASA))
            escenariosSpriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = escenarios[21].ImagenEscenarios;

        if (E_escenarios.Equals(Escenarios.CUARTO))
            escenariosSpriteRenderer.gameObject.GetComponent<SpriteRenderer>().sprite = escenarios[1].ImagenEscenarios;



    ////ESTADO DEL PERSONAJE------------ LETRA
  
        if(E_Sentir.Equals(SentimientosNiñoLetra.NORMAL))
        L_NORMAL();
        if (E_Sentir.Equals(SentimientosNiñoLetra.MIEDO))
        L_MIEDO();

        if(E_Sentir.Equals(SentimientosNiñoLetra.EXTRAÑO))   
        L_EXTRAÑO();


    ////ESTADO DEL PERSONAJE------------ ANIMACION DE DESVANECER PERSONAJE
            if (E_estados.Equals(Estados.HIDE))
        {
            if (Transparencia <= 0)
                E_estados = Estados.NOTHING;

            Transparencia -= Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Transparencia);
        }
        if (E_estados.Equals(Estados.SHOW))
        {
            if (Transparencia >= 1)
                E_estados = Estados.NOTHING;

            Transparencia += Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Transparencia);
        }
    }


  

IEnumerator ExecuteAfterTime(float time)
 {
     yield return new WaitForSeconds(time);
    
 
     // Code to execute after the delay
 }
    public void pauseGame(){

            Pausa=true;
    }
     public void DesPausa(){

            Pausa=false;
               
    }
  
 void EstadosImagen(){


     
    Ovejita_Normal=Resources.Load<Sprite>("Personajes/Ovejita/OVEJITA_NORMAL");   
    Ovejita_Llorando=Resources.Load<Sprite>("Personajes/Ovejita/OVEJITA_LLORANDO");  
    Ovejita_Asustada=Resources.Load<Sprite>("Personajes/Ovejita/OVEJITA_ASUSTADA");  
    Ovejita_Caballera_Demonio=Resources.Load<Sprite>("Personajes/Ovejita/OVEJITA_CABALLERA_DEMONIO");              
    Ovejita_Caballera_Pescados=Resources.Load<Sprite>("Personajes/Ovejita/OVEJITA_CABALLERA_PESCADO");              

    Padres_Normal=Resources.Load<Sprite>("Personajes/Padres/PADRES_NORMAL");

    Estrella_Normal=Resources.Load<Sprite>("Personajes/Estrella/ESTRELLA_NORMAL");
    Estrella_Asustada=Resources.Load<Sprite>("Personajes/Estrella/ESTRELLA_ASUSTADA");
    Estrella_Malvada=Resources.Load<Sprite>("Personajes/Estrella/ESTRELLA_MALVADA");

    Demonio_Normal=Resources.Load<Sprite>("Personajes/Demonio/DEMONIO_NORMAL");
    Demonio_Asustado=Resources.Load<Sprite>("Personajes/Demonio/DEMONIO_ASUSTADO");

    Mago_Normal=Resources.Load<Sprite>("Personajes/Mago/MAGO_NORMAL");

    Pez_Normal=Resources.Load<Sprite>("Personajes/Pez/PEZ_NORMAL");
    Pez_Agonizante=Resources.Load<Sprite>("Personajes/Pez/PEZ_AGONIZANTE");
    
    expresiones_Fisicas[0].ImagenPersonaje= Ovejita_Normal;
    expresiones_Fisicas[1].ImagenPersonaje= Ovejita_Llorando;
    expresiones_Fisicas[2].ImagenPersonaje= Ovejita_Asustada;
    expresiones_Fisicas[3].ImagenPersonaje= Ovejita_Caballera_Demonio;
    expresiones_Fisicas[4].ImagenPersonaje= Ovejita_Caballera_Pescados;

    expresiones_Fisicas[5].ImagenPersonaje= Padres_Normal;

    //expresiones_Fisicas[6].ImagenPersonaje= Estrella_Normal;
    //expresiones_Fisicas[7].ImagenPersonaje= Estrella_Asustada;
    //expresiones_Fisicas[8].ImagenPersonaje= Estrella_Malvada;

    //expresiones_Fisicas[9].ImagenPersonaje= Demonio_Normal;
    //expresiones_Fisicas[10].ImagenPersonaje= Demonio_Asustado;

    //expresiones_Fisicas[11].ImagenPersonaje= Mago_Normal;

    //expresiones_Fisicas[12].ImagenPersonaje= Pez_Normal;
    //expresiones_Fisicas[13].ImagenPersonaje= Pez_Agonizante;
    
  
 }

 void EstadoEscenario(){
     Escenario_Cocina=Resources.Load<Sprite>("Escenarios/Cocina");
     Escenario_CuartoThomas=Resources.Load<Sprite>("Escenarios/CuartoThomas");

     escenarios[21].ImagenEscenarios=Escenario_Cocina;
     escenarios[1].ImagenEscenarios=Escenario_CuartoThomas;

     
 }


 void CapturarBotones()
 {

     Izquierda=GameObject.Find("Izquierda").GetComponent<Button>();
     Derecha=GameObject.Find("Derecha").GetComponent<Button>();  
     
     A_Izquierda=GameObject.Find("A_Izquierda").GetComponent<Button>();
     A_Derecha=GameObject.Find("A_Derecha").GetComponent<Button>();  
  
   
   
 }


///////COLUMNA DE TEXTOS CUANDO INICIE

 static int sumaTexto(int _NumDialog){
     NumDialog=_NumDialog+1;
     return _NumDialog;
 }
///////////////////////////////////////////////////////////////
   void InicioGame(){

       //    public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos)
       

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("¿Qué ha sido ese ruido?",.2f,40,SentimientosNiñoLetra.NORMAL,EstadosFisicos.DEMONIO_NORMAL,Escenarios.CASA1);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("*Abre la puerta*",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.PADRES_NORMAL,Escenarios.CASA1,"Marco","Sheep");
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Me pregunto que habrá sido",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA,Escenarios.CASA1,"Marco","Bells");
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,Izquierda,Derecha);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Vamos",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_DEMONIO);
            
    }
////////////////////////////////////////////////////DESICION 0////////////////////////////////////////////////////
    void QuedarteCasa(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Que es esto",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,A_Izquierda,A_Derecha);


    }
      void Escapar(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Ahuevooo, me escape",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA);
             dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,E_Izquierda,E_Derecha);
        

    }
    ///////////////////////////////////////////DESICION A///////////////////////////////////////////////////////////////////////////////////////////////
     void HaciaDestello(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Fui Al destello",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,B_Izquierda,B_Derecha);



    }
      void Sabanas(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Oculte Bajo Sabanas",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_NORMAL);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Me chingue BAD ENDING",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA);


    }
    ///////////////////////////////////////////DESICION B///////////////////////////////////////////////////////////////////////////////////////////////
   void AyudarDestello(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Ayudar Destello",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,C_Izquierda,C_Derecha);



    }
      void IgnorarDestello(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Ahuevooo, No ayude al destello",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Me chingue BAD ENDING",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);

    }
        ///////////////////////////////////////////DESICION C///////////////////////////////////////////////////////////////////////////////////////////////

    
   void AtacarDemonio(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Atacar Demonio",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Me chingue BAD ENDING",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);


    }
      void Dudar(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Ahuevooo, le dude",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,D_Izquierda,D_Derecha);


    }

            ///////////////////////////////////////////DESICION D///////////////////////////////////////////////////////////////////////////////////////////////
  void Creerle(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Creerle",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);
         dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Me chingue good ending",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);

    }
      void MatarDemonio(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Ahuevooo, Lo mate",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA);
         dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Me chingue BAD ENDING",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);

    }

    
            ///////////////////////////////////////////DESICION F///////////////////////////////////////////////////////////////////////////////////////////////
  void Cantinplora(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Cantinplora",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,F_Izquierda,F_Derecha);

    }
      void NegarseCantinplora(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Ahuevooo, Me negue a darle una cantinplora",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("Me chingue BAD ENDING",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);

    }

        
            ///////////////////////////////////////////DESICION G///////////////////////////////////////////////////////////////////////////////////////////////
  void AceptarRegalo(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("AcepteRegalo",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_CABALLERA_PESCADO);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,G_Izquierda,G_Derecha);

    }
      void NegarRegalo(){

        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("No quiero su caridad",.01f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_ASUSTADA);
        dialogoEnsayo[sumaTexto(NumDialog)].setTODO("A donde debería ir",-1f,60,SentimientosNiñoLetra.NORMAL,EstadosFisicos.OVEJITA_LLORANDO,Escenarios.CASA1,"Marco",true,H_Izquierda,H_Derecha);


    }


    
    


void EscenarioParpadeo()
    {
        
     
        

    }



    //ESTADO TEXTO_MIEDO
    void L_MIEDO()
    {
        
        TextMesh = txt_Dialogo.mesh;
        vertices = TextMesh.vertices;


        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i);
            
            vertices[i] = vertices[i] + offset;
           
        }
     


        TextMesh.vertices = vertices;
        txt_Dialogo.canvasRenderer.SetMesh(TextMesh);
        

    }

    ///ESTADO TEXTO_EXTRAÑO
    void L_EXTRAÑO()
    {
        //txt_Dialogo.fontMaterial.SetFloat(ShaderUtilities.ID_FaceColor, 0.5f);
           txt_Dialogo.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, 0.5f);
        //txt_Dialogo.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.5f);
    }
    
    void L_NORMAL()
    {
        //txt_Dialogo.fontMaterial.SetFloat(ShaderUtilities.ID_FaceColor, 0.5f);
           txt_Dialogo.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, 0);
        //txt_Dialogo.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.5f);
    }



     

    void Empezar_Conversacion()
    {
        dialogo.SetActive(true);

        StartCoroutine(Talk(dialogoEnsayo));
    }



    /////Deletero de  palabras
    public IEnumerator Talk(Talking[]_dialogo)
    {
      
        dialogo.SetActive(true);
     
            for (int i = 0; i < _dialogo.Length; i++)
        {

            txt_Dialogo.font = fontGeneral;
           
           
            if (i == 1)

                E_estados = Estados.SHOW;
                

              
              
 
         
            if (_dialogo[i].FrontSize == 0)

                txt_Dialogo.fontSize = 35;

            else
                txt_Dialogo.fontSize = _dialogo[i].FrontSize;


            foreach (char character in _dialogo[i].texto)
            {
                txt_Dialogo.text = txt_Dialogo.text + character;
                if(_dialogo[i].time==0)
                     yield return new WaitForSeconds(.02f);
                else
                     yield return new WaitForSeconds(_dialogo[i].time);

               
                E_Sentir = _dialogo[i].Sentir;
                E_estadosFisicos = _dialogo[i].estadosfisicos;
                E_escenarios = _dialogo[i].escenarios;
                txt_NombreDialogo.text = _dialogo[i].NombrePersonaje;
                if(!UnaVez)
                SoundManager.PlaySound(_dialogo[i].SFX);
                UnaVez=true;
                if(_dialogo[i].Izquierda!=null)
                ActivarBotones(_dialogo[i].Izquierda,_dialogo[i].Derecha);
                Pausa=_dialogo[i].Pausa;
            }

        if(Pausa){
            yield return new WaitUntil(() =>!Pausa);
        }
         else{    
            yield return new WaitForSeconds(.5f);
            yield return new WaitUntil(() => Input.GetKeyUp(teclaSiguiente)|| Input.GetKey(teclaSiguiente2));
         }
          UnaVez=false;
          DesactivarBotones();

            txt_Dialogo.text = "";
        }
        E_estados = Estados.HIDE;
        yield return new WaitForSeconds(1);
        dialogo.SetActive(false);

      

    }

    Vector2 Wobble(float time)
    {
        return new Vector2(5*(Mathf.Cos(time * 100.3f)), 5*(Mathf.Cos(time * 100.1f)));
    }
 
}




[System.Serializable]
public class Talking
{
    public string texto;
    public float time;
    public int FrontSize;
    public SentimientosNiñoLetra Sentir;
    public EstadosFisicos estadosfisicos;
    public Escenarios escenarios;
    public string NombrePersonaje;
    public string SFX;
    public bool Pausa;

    public Button Izquierda;
    public Button Derecha;
public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos,Escenarios escenarios,string NombrePersonaje,bool Pausa,Button Izquierda,Button Derecha)
    {
        this.texto = texto;
        
        this.time = time;

        this.FrontSize = FrontSize;

        this.Sentir = Sentir;
         
        this.estadosfisicos = estadosFisicos;

        this.escenarios = escenarios;

        this.NombrePersonaje = NombrePersonaje;

        this.Pausa=Pausa;
        
        this.Izquierda=Izquierda;

        this.Derecha=Derecha;

    }
public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos,Escenarios escenarios,string NombrePersonaje,bool Pausa)
    {
        this.texto = texto;
        
        this.time = time;

        this.FrontSize = FrontSize;

        this.Sentir = Sentir;
         
        this.estadosfisicos = estadosFisicos;

        this.escenarios = escenarios;

        this.NombrePersonaje = NombrePersonaje;

        this.Pausa=Pausa;

    }

public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos,Escenarios escenarios,string NombrePersonaje,string SFX,bool Pausa)
    {
        this.texto = texto;
        
        this.time = time;

        this.FrontSize = FrontSize;

        this.Sentir = Sentir;
         
        this.estadosfisicos = estadosFisicos;

        this.escenarios = escenarios;

        this.NombrePersonaje = NombrePersonaje;

        this.SFX=SFX;

        this.Pausa=Pausa;

    }
public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos,Escenarios escenarios,string NombrePersonaje,string SFX)
    {
        this.texto = texto;
        
        this.time = time;

        this.FrontSize = FrontSize;

        this.Sentir = Sentir;
         
        this.estadosfisicos = estadosFisicos;

        this.escenarios = escenarios;

        this.NombrePersonaje = NombrePersonaje;

        this.SFX=SFX;

    }
public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos,Escenarios escenarios,string NombrePersonaje)
    {
        this.texto = texto;
        
        this.time = time;

        this.FrontSize = FrontSize;

        this.Sentir = Sentir;
         
        this.estadosfisicos = estadosFisicos;

        this.escenarios = escenarios;

        this.NombrePersonaje = NombrePersonaje;

    }
    public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos,Escenarios escenarios)
    {
        this.texto = texto;
        
        this.time = time;

        this.FrontSize = FrontSize;

        this.Sentir = Sentir;
         
        this.estadosfisicos =estadosFisicos;
        
        this.escenarios=escenarios;

    }
    public void setTODO(string texto,float time,int FrontSize,SentimientosNiñoLetra Sentir,EstadosFisicos estadosFisicos)
    {
        this.texto = texto;
        
        this.time = time;

        this.FrontSize = FrontSize;

        this.Sentir = Sentir;
         
        this.estadosfisicos =estadosFisicos;

    }
    
    public string getTexto()
    {
        return this.texto;
    }

    public void setTexto(string texto)
    {
        this.texto = texto;
    }

    public float getTime()
    {
        return this.time;
    }

    public void setTime(float time)
    {
        this.time = time;
    }

    public int getFrontSize()
    {
        return this.FrontSize;
    }

    public void setFrontSize(int FrontSize)
    {
        this.FrontSize = FrontSize;
    }

    public SentimientosNiñoLetra getSentir()
    {
        return this.Sentir;
    }

    public void setSentir(SentimientosNiñoLetra Sentir)
    {
        this.Sentir = Sentir;
    }

    public EstadosFisicos getEstadosfisicos()
    {
        return this.estadosfisicos;
    }

    public void setEstadosfisicos(EstadosFisicos estadosfisicos)
    {
        this.estadosfisicos = estadosfisicos;
    }

    //public Font font;
}
[System.Serializable]
public class Expresiones_Fisicas
{
    public Sprite ImagenPersonaje;




};
[System.Serializable]

public class Clase_escenarios
{
    public Sprite ImagenEscenarios;


};

       
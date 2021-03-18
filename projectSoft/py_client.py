import requests
import argparse
import json
import os

#https://csharp2json.io/
#MM-DD-YY

# python .\prueba.py -p GET -l http://localhost:49913/api/Publicacion
# 

publicaciones=[
    {
        "idPublicacion": 105,
        "idUsuario": 2,
        "fecha": "1980-01-18T16:31:37.94",
        "descripcion": "DAVID",
        "imagen": "http://vehistito.com/ereentfor/er/esnt/reevebutha.bmp",
        "com": [
            1
        ]
    },
    {
        "idPublicacion": 105,
        "idUsuario": 1,
        "fecha": "1980-01-18T16:31:37.94",
        "descripcion": "DAVID3",
        "imagen": "http://vehistito.com/ereentfor/er/esnt/reevebutha.bmp",
        "com": [
            1
        ]
    }
]

usuario={
    "nombres": "Cristian",
    "apellidos": "Cruz",
    "email": "dsfdf@dsfdf",
    "fechaNacimiento": "05-27-1995",
    "telefono": "234324",
    "activo": False
}


def get_parametros():
    parser = argparse.ArgumentParser(description="Argumentos")
    parser.add_argument('-l', '--link', help="Url del servidor")
    parser.add_argument('-p', '--protocol', help="Tipo de peticion")
    return parser.parse_args()

def enviar_peticion(tipo,url,data):
    headers = {
      'Content-Type': 'application/json;charset=utf-8'
    }
    response = requests.request(tipo, url, headers=headers, data=json.dumps(data))
    os.system('cls')
    print("->",response.status_code,"<-")
    if(response.status_code == 200):
        print(json.dumps(json.loads(response.text), sort_keys=True, indent=4))
    else:
        print(response.text)


enviar_peticion(get_parametros().protocol,get_parametros().link,publicaciones)
 

import os
import pandas as pd

txt = "embriologia.txt"

f = open(txt, 'r')
texto = f.readlines()

# classe questão
class classname(object):
    pass

for linha in texto:
    # achar padrão de #) no início para identificar questão nova
    # criar novo objeto questão
    # ler até achar o próximo início de questão
    print(linha)

f.close()

# Descartar questões com figura
# Descartar linhas vazias
# Segmentar alternativas

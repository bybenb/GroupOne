# Hvwh surjudpd irl ihlwr shor 'JurxsRqh'


def dcc3(texto, deslocamento=3):
    sms = ""
    for char in texto:
        if char.isalpha():
            novo_char = chr(((ord(char.lower()) - ord('a') - deslocamento) % 26) + ord('a'))
            if char.isupper():
                novo_char = novo_char.upper()
            sms += novo_char
        else:
            sms += char
    return sms

def ccc3(texto, deslocamento=3):
    sms = ""
    
    
    for char in texto:
        
        if char.isalpha():
            base = ord('A') if char.isupper() else ord('a')
            novo_char = chr((ord(char) - base + deslocamento) % 26 + base)
            sms += novo_char
        else:
            sms += char

    return sms



texto_original = input("CC3: ")
texto_codificado = ccc3(texto_original, deslocamento=3)

print(texto_codificado)


texto_codificado = input("DCC3: ")
texto_decodificado = dcc3(texto_codificado)
print(texto_decodificado)

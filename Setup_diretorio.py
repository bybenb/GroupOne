from pathlib import Path


base = Path('bybenb\projecto\mvp-versao-1.0')


pastas = [
    "Telas",
    "Componentes",
    "Modelos",
    "Servicos",
    "BancoDados",
    "Utilitarios"
]


for pasta in pastas:
    dir_path = base / pasta
    dir_path.mkdir(parents=True, exist_ok=True)

    # padrao = f"""
    # // Arquivo de exemplo para a pasta {pasta}\n
    # using System;\n
    # using System.Windows.Forms;\t\t\t// O proprio gajo \n
    # using System.Drawing;   // 2-5-14-25\n
    # using MySql.Data.MySqlClient;\n
    # using System.Collections.Generic;\n
    # using System.ComponentModel; \n\n\n\n\n\n\n
    
    # Console.WriteLine(\"© 2025 Grupo One. Todos Direitos reservados à Eng. Joana Bungo.\");\n\n
    # /*\t\t\t\t====STAFF====\n
    # 1- Beny Reis🏀 @bkapa8\t\t2- Insano\n
    # 3- Marcos Mpelo\t\t4- Domingos Tandala\n
    # 5- Augusto Lopes\t\t6- Kevin Magalhaes 🦁\n
    # 7- Steam Blood 🎶\t\t8- Neidy Scobar\n
    # 9- Junilson Gomes\t\t10- Lord Sapiencia🎙🎤\n*/"""
    
    exemplo = dir_path / f"Exemplo_{pasta}.cs"
    # exemplo.write_text(padrao)
    exemplo.write_text('// Arquivo de exemplo para a pasta {pasta}\n')
    exemplo.write_text('using System;\n')
    exemplo.write_text('using System.Windows.Forms;\t\t\t// O proprio gajo \n')
    exemplo.write_text('using System.Drawing;   // 2-5-14-25\n')
    exemplo.write_text('using MySql.Data.MySqlClient;    \t\t\t\t\t// dotnet add package MySql.Data --source https://api.nuget.org/v3/index.json\n')
    exemplo.write_text('using System.Collections.Generic;\n')
    exemplo.write_text('using System.ComponentModel; \n\n\n\n\n\n\n')
    
    exemplo.write_text('Console.WriteLine(\"© 2025 Grupo One. Todos Direitos reservados à Eng. Joana Bungo.\");\n\n')
    exemplo.write_text('/*\t\t\t\t====STAFF====\n')
    exemplo.write_text('1- Beny Reis @bkapa8\t\t2- Insano\n')
    exemplo.write_text('3- Marcos Mpelo\t\t4- Domingos Tandala\n')
    exemplo.write_text('5- Augusto Lopes\t\t6- Kevin Magalhaes \n')
    exemplo.write_text('7- Steam Blood \t\t8- Neidy Scobar\n')
    exemplo.write_text('9- Junilson Gomes\t\t10- Lord Sapiencia\n*/')
        


(base / "Program.cs").write_text("// Ponto de entrada do sistema\n")
(base / "App.config").write_text("<!-- Configurações do banco -->\n")
(base / "README.md").write_text("# Projeto do GrupoOne\n\nDocumentação inicial.\n")


# Retornar caminho do projeto
print(f"\nO projecto foi criado com exito neste caminho\n>>> \"{base.as_posix()}\"")
input()

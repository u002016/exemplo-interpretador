# InterpretadorCSharp
Interpreta trechos de código C# utilizando a biblioteca Microsoft.CodeAnalysis.CSharp
Permite customizar funções de cálculo

## Utiliza basicamente duas classes

**Contexto** - classe que deve ser passada para o intepretado com os dados de entrada
**Result** - classe que será repassada para o interpretador com os dados calculados de saída.
Ex.: 

>       //definindo a classe de contexto    
>       public class ContextoExemplo{
>            public int Numero {get; set}
>        } 

>        //definindo a classe de resultado
>        public class ResultadoExemplo
>        {
>             public int Quadrado {get; set}
>        }


 >      //definindo a formula de calculo
 >       const string SFormula = "result.Quadrado = context.Numero * context.Numero" ;


>       //executando a formula
>       var contexto = new ContextoExemplo()
>       {
>             Numero = 4;
>       }
>       var agent = new InterpreterAgent<ContextoExemplo, ResultadoExemplo>(SFormula);
>
>       var result = agent.Execute(contexto);
>       console.Write(result.Quadrado); //espera-se 16

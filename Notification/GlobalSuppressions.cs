// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Nem Sempre faz sentido documentar tudo obrigatóriamente (Existem casos muito simples). Mas quando se tem um sumário acredito que o mesmo tenha que seguir os padrões")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1200:Using directives should be placed correctly", Justification = "A forma de trabalhar os usings deve ser do controle do programador. Evitar erros de classe duplicada é um dever do mesmo e o compilador já ajuda nesse papel")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Caso complicado, considerando que classes injetadas devem ter _ o this como antecessor fica redundante. Acredito que no momento a decisão é deixar a cargo do dev")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Conforme recomendado injecos de depencia devem ser precedidadas do prefixo _ logo a regra impedindo o uso do mesmo se torna inaplicável")]
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:Closing parenthesis should be spaced correctly", Justification = "Nem todos os casos após o parenteses um espaço fica adequado")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:File should have header", Justification = "Acredito que criar cabeçalho de arquivo seja meio desnecessário")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1601:Partial elements should be documented", Justification = "Acredito que criar cabeçalho de arquivo seja meio desnecessário")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1413:Use trailing comma in multi-line initializers", Justification = "Não faz sentido adicionar a ultima virgula obrigatóriamente sendo que não teremos novos parâmetros")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented", Justification = "Acredito que criar cabeçalho de arquivo seja meio desnecessário")]

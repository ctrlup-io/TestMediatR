# TestMediatR (CRUD)
Solution de test de MediatR en architecture DDD.
Particularié : La couche "Application" n'est pas celle du projet principal. Ceci afin de déporter la logique "métier" ailleurs que sur le projet qui contient le controller.
Ceci n'est pas iso avec l'archi préconisée par Microsoft.

# Objet du test
L'idée est de tester l'archi en CQRS (qui pour ce genre de projet n'est pas recommandée car beaucoup de code pour pas grand chose...).

# DataStore
Objectif : Mixer Entity et Dapper (+ Automapper)
## Pourquoi ?
Entity est extrêmement souple popur gérer les versions de bases de données. Il reste néanmoins critiqué sur ses perfs.
L'idée donc, c'est d'orienter cette API sur de la perf mais ne pas se priver des fonctionnalités Entity.

### Partage de responsabilité
Entity va avoir la responsabilité des versions de bases ainsi que de la génération des procédures stockées.
Dapper (réputé perf) va appeler ces procédures stockées.

### Pas d'utilisation d'Entity ? Vraiment ?
Si ! Uniquement pour vérifier l'existence d'un item avec la méthode(linq) 'Any' (donc très rapide)

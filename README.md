# TestMediatR (CRUD)
Solution de test de MediatR en architecture DDD.
Particularié : La couche "Application" n'est pas celle du projet principal. Ceci afin de déporter la logique "métier" ailleurs que sur le projet qui contient le controller.
Ceci n'est pas iso avec l'archi préconisée par Microsoft.

# Objet du test
L'idée est de tester l'archi en CQRS (qui pour ce genre de projet n'est pas recommandée car beaucoup de code pour pas grand chose...).

# FakeDataStore va être remplacé par une vraie BDD
Objectif : Mixer Entity et Dapper.

# PortMontreal
 Projet en .net 8
 
 Technologie utilisée : Entity Framework Core

 - La branche master contient une solution avec deux classes, soit Départ et Arrivée
 - La brandhe trajet contient une solution avec une classe mère Trajet, et deux classes enfants, soit Départ et Arrivée
	- Le Owned Entity Types est utilisée, ce qui simplifie le code c# et sql et la lecture d'un trajet complet
	- Plus simple au niveau de l'API comme il n'y a qu'un seul contrôleur Trajet
	- La méthode Put n'est pas implémentée au complet, mais le concept y est

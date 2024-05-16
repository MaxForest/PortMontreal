# PortMontreal
 Projet en .net 8
 
 Technologie utilisée : Entity Framework Core
 
 Améliorations possibles : 
 - Les modèles Depart et Arrivee pourraient dérivés de la même classe  Itinéraire et partager les variables : NomNavire, Port et TypeCargaison
	- On pourrait avoir trois tables dans la base de données (Depart, Arrivee et Itinéraire), Depart et Arrivee en dériveront
	- C'est du moins la particularité en utilisant Entity Framework Core, les classes asbtraites et les classes dérivées sont découpées de la même façon au niveau sql
 - Dans la base de données, on pourrait avoir une table Port et ainsi avoir des relations entre (Depart, Arrive) et Port
 - TypeCargaison pourrait être de type Enum dans le code, avec sa propre table dans la base de données (Lié en FK)
 - Les Get() et Get(int id) pourraient être ajoutés dans le BaseRepository avec de la reflection, ainsi il n'y aurait qu'une seule méthode Get() et Get(int id)
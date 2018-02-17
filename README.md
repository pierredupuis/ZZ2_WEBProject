# ZZ2_WEBProject
Projet web de ZZ2 (F2&amp;F5)


# Avancement :

* Base de données : -
* BusinessLayer : -
* API : Méthodes implémentés non encore téstés (dépendance BusinessLayer)
* Web App : Listes d'éléments, Vues 'Create' pour House et Character. Attente de l'avancement de l'API pour créer/tester des vues 'Create', 'GetByID', 'Delete', 'Edit'

# Penser à
* Changer le path de la Base de Données selon le PC
* Changer les numéros de port de chaque fonction des Controller de la WebApp si besoin
   -> _Faire une classe statique contenant des variables api_port, webapp_port pour simplifier la modif_

# API
Je sais pas si ça correspond exactement, mais j'ai listé les fonctions à faire. Modifie si ça correspond pas ou s'il en manque.
* Character
  * [X] GetAll
  * [ ] GetByID(id)
  * [ ] Post(Character)
  * [ ] Delete(id)
* Fight
  * [ ] GetAll
  * [ ] GetByID(id)
  * [ ] Post(Fight)
  * [ ] Delete(id)
* House
  * [ ] GetAll
  * [ ] GetByID(id)
  * [ ] Post(House)
  * [ ] Delete(id)
* Territory
  * [ ] GetAll
  * [ ] GetByID(id)
  * [ ] Post(Territory)
  * [ ] Delete(id)
* War
  * [ ] GetAll
  * [ ] GetByID(id)
  * [ ] Post(War)
  * [ ] Delete(id)
  
# Web App
Seuls les Index (Liste tous les éléments) ont été testés. Attente de l'API pour tester le reste.
* Character
  * [X] Index
  * [ ] Get(id)
  * [X] Create
  * [ ] Edit
  * [ ] Delete
* Fight
  * [X] Index
  * [ ] Get(id)
  * [X] Create
  * [ ] Edit
  * [ ] Delete
* House
  * [X] Index
  * [ ] Get(id)
  * [X] Create
  * [ ] Edit
  * [ ] Delete
* Territory
  * [X] Index
  * [ ] Get(id)
  * [ ] Create
  * [ ] Edit
  * [ ] Delete
* War
  * [X] Index
  * [ ] Get(id)
  * [ ] Create
  * [ ] Edit
  * [ ] Delete

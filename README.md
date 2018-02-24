# ZZ2_WEBProject
Projet web de ZZ2 (F2&amp;F5)


# Avancement :

* Base de données : Même avancement que l'API
* BusinessLayer : Implémentation des opérations demandés pour les classes : House, Fight et Character.
* API : Méthodes implémentés non encore téstés (dépendance BusinessLayer)
* Web App : Listes d'éléments, Vues 'Create' pour House et Character. Attente de l'avancement de l'API pour créer/tester des vues 'Create', 'GetByID', 'Delete', 'Edit'

# Penser à
* Changer le path de la Base de Données selon le PC  (DataAccessLayer, DalManager.cs, l. 13-16)
* Changer les numéros de port dans la classe statique "Globals" si besoin

# API

* Character
  * [x] GetAll
  * [x] GetByID(id)
  * [x] Post(Character)
  * [x] Edit(Character)
  * [x] Delete(id)
* Fight
  * [x] GetAll
  * [x] GetByID(id)
  * [x] Post(Fight)
  * [x] Edit(Fight)
  * [x] Delete(id)
* House
  * [x] GetAll (ne prends pas encore en charge housers)
  * [x] GetByID(id)
  * [x] Post(House)
  * [x] Edit(House)
  * [x] Delete(id) (devra peut être supprimer aussi les housers ? )
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
* [ ] Character
  * [X] Index
  * [X] Get(id)
  * [X] Create
  * [X] Edit
  * [X] Delete
  * [ ] Fonctions testées 1/5
* [ ] Fight
  * [X] Index
  * [X] Get(id)
  * [X] Create
  * [X] Edit
  * [X] Delete
  * [ ] Fonctions testées 1/5
* [X] House
  * [X] Index
  * [X] Get(id)
  * [X] Create
  * [X] Edit
  * [X] Delete
  * [X] Fonctions ci-dessus testées (Controller API de Test, HouseTestController.cs)
* [ ] Territory
  * [X] Index
  * [X] Get(id)
  * [ ] Create
  * [X] Edit
  * [X] Delete
  * [ ] Fonctions testées  1/5
* [ ] War
  * [X] Index
  * [X] Get(id)
  * [ ] Create
  * [X] Edit
  * [X] Delete
  * [ ] Fonctions testées 1/5

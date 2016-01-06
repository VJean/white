using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour 
{
    #region Attributs
    public int _width, _height; //Largeur et hauteur du labyrinthe.

    public VisualCell visualCellPrefab; // Prefab qui sert de modèle à l'instanciation.

    public Cell[,] cells; //Tableau de cellules a deux dimensions.

    private Vector2 _randomCellPos; //Position de la cellule aleatoire qui va commencer la generation.
    private VisualCell visualCellInst; // Contient la copie du prefab de l'instanciation.

    private List<CellAndRelativePosition> neighbors; //Liste des cellules voisines
    #endregion

    #region Propriétés
    #endregion

    #region Enums
    #endregion

    #region Méthodes
    void Start ()
    {
        cells = new Cell[_width, _height]; //Initialisation du tableau de cellules
        Init(); //Lance la fonction Init
    }

    void Init ()
    {
        for(int i = 0; i < _width; i++)
        {

            for(int j = 0; j < _height; j++)
            {

                cells[i, j] = new Cell(false, false, false, false, false);
                cells[i, j].xPos = i;
                cells[i, j].zPos = j;
            }
        }
        RandomCell(); //Lance la fonction RandomCell

        InitVisualCell(); //Lance l'instantiation des cellules visuel
    }

    void RandomCell ()
    {
        //Recupere une position X et Y aleatoire
        _randomCellPos = new Vector2((int)UnityEngine.Random.Range(0, _width), (int)UnityEngine.Random.Range(0, _height));

        //Lance la fonction GenerateMaze avec la positions X et Y aleatoire.
        GenerateMaze((int)_randomCellPos.x, (int)_randomCellPos.y); 
    }

    void GenerateMaze (int x, int y)
    {
        //	Debug.Log("Doing " + x + " " + y);
        Cell currentCell = cells[x, y]; //Definit la cellule courante
        neighbors = new List<CellAndRelativePosition>(); //Initialise la liste
        if(currentCell._visited == true) return;
        currentCell._visited = true;

        if(x + 1 < _width && cells[x + 1, y]._visited == false)
        { //Si on est pas a la largeur limite max du laby et que la cellule de droite n'est pas visiter alors on peut aller a droite
            neighbors.Add(new CellAndRelativePosition(cells[x + 1, y], CellAndRelativePosition.Direction.East)); //Ajoute la cellule voisine de droite dans la liste des voisins
        }

        if(y + 1 < _height && cells[x, y + 1]._visited == false)
        { //Si on est pas a la longueur limite du laby et que la cellule du bas n'est pas visiter alors on peut aller en bas
            neighbors.Add(new CellAndRelativePosition(cells[x, y + 1], CellAndRelativePosition.Direction.South)); //Ajoute la cellule voisine du bas dans liste des voisins
        }

        if(x - 1 >= 0 && cells[x - 1, y]._visited == false)
        { //Si on est pas a la largeur limite mini du laby et que la cellule de gauche n'est pas visiter alors on peut aller a gauche
            neighbors.Add(new CellAndRelativePosition(cells[x - 1, y], CellAndRelativePosition.Direction.West)); //Ajoute la cellule voisine de gauche dans la liste des voisins
        }

        if(y - 1 >= 0 && cells[x, y - 1]._visited == false)
        { //Si on est pas a la longueur limite mini du laby et que la cellule du haut n'est pas visiter alors on peut aller en haut
            neighbors.Add(new CellAndRelativePosition(cells[x, y - 1], CellAndRelativePosition.Direction.North)); //Ajoute la cellule voisine du haut dans la liste des voisins
        }

        if(neighbors.Count == 0) return;  // Si il y a 0 voisins dans la liste on sort de la méthode.

        neighbors.Shuffle(); // Melange la liste de voisins

        foreach(CellAndRelativePosition selectedcell in neighbors)
        {
            if(selectedcell.direction == CellAndRelativePosition.Direction.East)
            { // A droite
                if(selectedcell.cell._visited) continue;
                currentCell._Est = true; //Detruit le mur de droite de la cellule courante
                selectedcell.cell._West = true; //Detruit le mur de gauche de la cellule voisine choisie
                GenerateMaze(x + 1, y); //Relance la fonction avec la position de la cellule voisine
            }

            else if(selectedcell.direction == CellAndRelativePosition.Direction.South)
            { // En bas
                if(selectedcell.cell._visited) continue;
                currentCell._South = true; //Detruit le mur du bas de la cellule courante
                selectedcell.cell._North = true; //Detruit le mur du haut de la cellule voisine choisie
                GenerateMaze(x, y + 1); //Relance la fonction avec la position de la cellule voisine
            }
            else if(selectedcell.direction == CellAndRelativePosition.Direction.West)
            { // A gauche
                if(selectedcell.cell._visited) continue;
                currentCell._West = true; //Detruit le mur de gauche de la cellule courante
                selectedcell.cell._Est = true; //Detruit le mur de droite de la cellule voisine choisie
                GenerateMaze(x - 1, y); //Relance la fonction avec la position de la cellule voisine
            }
            else if(selectedcell.direction == CellAndRelativePosition.Direction.North)
            { // En haut
                if(selectedcell.cell._visited) continue;
                currentCell._North = true; //Detruit le mur du haut de la cellule courante
                selectedcell.cell._South = true; //Detruit le mur du bas de la cellule voisine choisie
                GenerateMaze(x, y - 1); //Relance la fonction avec la position de la cellule voisine
            }
        }


    }

    void InitVisualCell ()
    {
        // Initialise mes cellules visuel et detruit les murs en fonction des cellules virtuel
        foreach(Cell cell in cells)
        {

            visualCellInst = Instantiate(visualCellPrefab, new Vector3(cell.xPos * 3, 0, _height * 3f - cell.zPos * 3), Quaternion.identity) as VisualCell;
            visualCellInst.transform.parent = transform;
            visualCellInst._North.gameObject.SetActive(!cell._North);
            visualCellInst._South.gameObject.SetActive(!cell._South);
            visualCellInst._Est.gameObject.SetActive(!cell._Est);
            visualCellInst._West.gameObject.SetActive(!cell._West);

            visualCellInst.transform.name = cell.xPos.ToString() + "_" + cell.zPos.ToString();
        }

    }
    #endregion
}

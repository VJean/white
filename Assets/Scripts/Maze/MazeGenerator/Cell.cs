public class Cell 
{
    #region Attributs
    public bool _West, _North, _Est, _South;    // Mur Ouest, Nord, Est et Sud.
    public bool _visited;                       // Permet de savoir si oui ou non la cellule à était visiter.

    public int xPos, zPos;                      // Position en X et en Z.
    #endregion

    #region Propriétés
    #endregion

    #region Enums
    #endregion

    #region Constructeur
    // Constructeur.
    public Cell (bool west, bool north, bool est, bool south, bool visited)
    {
        this._West = west;
        this._North = north;
        this._Est = est;
        this._South = south;
        this._visited = visited;
    }
    #endregion

}

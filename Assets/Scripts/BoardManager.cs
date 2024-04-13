using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private int[,] board;

    enum Pieces
    {
        BLACK_KING,
        BLACK_QUEEN,
        BLACK_BISHOP,
        BLACK_KNIGHT,
        BLACK_ROOK,
        BLACK_PAWN,
        WHITE_KING,
        WHITE_QUEEN,
        WHITE_BISHOP,
        WHITE_KNIGHT,
        WHITE_ROOK,
        WHITE_PAWN
    };

    void Start()
    {
        board = new int[8, 8];
        InitializeBoard();
        PopulateBoard();
        PrintBoard();
        PopulateScene();
    }

    void InitializeBoard()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                board[x, y] = -1;
            }
        }
    }

    void PopulateBoard()
    {
        
        board[0, 0] = (int)Pieces.BLACK_ROOK;
        board[1, 0] = (int)Pieces.BLACK_KNIGHT;
        board[2, 0] = (int)Pieces.BLACK_BISHOP;
        board[3, 0] = (int)Pieces.BLACK_QUEEN;
        board[4, 0] = (int)Pieces.BLACK_KING;
        board[5, 0] = (int)Pieces.BLACK_BISHOP;
        board[6, 0] = (int)Pieces.BLACK_KNIGHT;
        board[7, 0] = (int)Pieces.BLACK_ROOK;
        for (int x = 0; x < 8; x++)
        {
            board[x, 1] = (int)Pieces.BLACK_PAWN;
        }

        
        board[0, 7] = (int)Pieces.WHITE_ROOK;
        board[1, 7] = (int)Pieces.WHITE_KNIGHT;
        board[2, 7] = (int)Pieces.WHITE_BISHOP;
        board[3, 7] = (int)Pieces.WHITE_QUEEN;
        board[4, 7] = (int)Pieces.WHITE_KING;
        board[5, 7] = (int)Pieces.WHITE_BISHOP;
        board[6, 7] = (int)Pieces.WHITE_KNIGHT;
        board[7, 7] = (int)Pieces.WHITE_ROOK;
        for (int x = 0; x < 8; x++)
        {
            board[x, 6] = (int)Pieces.WHITE_PAWN;
        }
    }


    void PrintBoard()
    {
        string s = "";
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                s += board[x, y] + "|";
            }
            s += "\n";
        }
        Debug.Log(s);
    }

    void PopulateScene()
    {
        float pieceSpacing = 1.1142857f;

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                int pieceEnum = board[x, y];
                if (pieceEnum != -1)
                {
                    string prefabName = GetPrefabName(pieceEnum);
                    Vector3 position = new Vector3(x * pieceSpacing, 0, y * pieceSpacing);
                    Instantiate(Resources.Load(prefabName), position, Quaternion.identity);
                }
            }
        }
    }

    string GetPrefabName(int enumNumber)
    {
        switch (enumNumber)
        {
            case (int)Pieces.BLACK_KING: return "bKing";
            case (int)Pieces.BLACK_QUEEN: return "bQueen";
            case (int)Pieces.BLACK_BISHOP: return "bBishop";
            case (int)Pieces.BLACK_KNIGHT: return "bKnight";
            case (int)Pieces.BLACK_ROOK: return "bRook";
            case (int)Pieces.BLACK_PAWN: return "bPawn";
            case (int)Pieces.WHITE_KING: return "wKing";
            case (int)Pieces.WHITE_QUEEN: return "wQueen";
            case (int)Pieces.WHITE_BISHOP: return "wBishop";
            case (int)Pieces.WHITE_KNIGHT: return "wKnight";
            case (int)Pieces.WHITE_ROOK: return "wRook";
            case (int)Pieces.WHITE_PAWN: return "wPawn";
            default: return "";
        }
    }
}

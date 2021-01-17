﻿using System;
using System.Collections.Generic;
using System.Text;

namespace C64Models.BASIC
{
  public class Opcode
  {
    public string         Command = "";
    public int            InsertionValue = -1;
    public string         ShortCut = null;

    public Opcode( string Command, int InsertionValue )
    {
      this.Command        = Command;
      this.InsertionValue = InsertionValue;
    }

    public Opcode( string Command, int InsertionValue, string ShortCut )
    {
      this.Command        = Command;
      this.InsertionValue = InsertionValue;
      this.ShortCut       = ShortCut;
    }
  };



  public class Dialect
  {
    public string                           Name = "";
    public Dictionary<string, Opcode>       Opcodes = new Dictionary<string, Opcode>();
    public SortedDictionary<ushort, Opcode> OpcodesFromByte = new SortedDictionary<ushort, Opcode>();
    public Dictionary<string, Opcode>       ExOpcodes = new Dictionary<string, Opcode>();

    public static Dialect                   BASICV2;



    static Dialect()
    {
      BASICV2 = new Dialect();
      BASICV2.Name = "BASIC V2";
      BASICV2.AddOpcode( "END", 0x80, "eN" );
      BASICV2.AddOpcode( "FOR", 0x81, "fO" );
      BASICV2.AddOpcode( "NEXT", 0x82, "nE" );
      BASICV2.AddOpcode( "DATA", 0x83, "dA" );
      BASICV2.AddOpcode( "INPUT#", 0x84, "iN" );
      BASICV2.AddOpcode( "INPUT", 0x85 );
      BASICV2.AddOpcode( "DIM", 0x86, "dI" );
      BASICV2.AddOpcode( "READ", 0x87, "rE" );
      BASICV2.AddOpcode( "LET", 0x88, "lE" );
      BASICV2.AddOpcode( "GOTO", 0x89, "gO" );
      BASICV2.AddOpcode( "RUN", 0x8A, "rU" );
      BASICV2.AddOpcode( "IF", 0x8B );
      BASICV2.AddOpcode( "RESTORE", 0x8C, "reS" );
      BASICV2.AddOpcode( "GOSUB", 0x8D, "goS" );
      BASICV2.AddOpcode( "RETURN", 0x8E, "reT" );
      BASICV2.AddOpcode( "REM", 0x8F );
      BASICV2.AddOpcode( "STOP", 0x90, "sT" );
      BASICV2.AddOpcode( "ON", 0x91 );
      BASICV2.AddOpcode( "WAIT", 0x92, "wA" );
      BASICV2.AddOpcode( "LOAD", 0x93, "lO" );
      BASICV2.AddOpcode( "SAVE", 0x94, "sA" );
      BASICV2.AddOpcode( "VERIFY", 0x95, "vE" );
      BASICV2.AddOpcode( "DEF", 0x96, "dE" );
      BASICV2.AddOpcode( "POKE", 0x97, "pO" );
      BASICV2.AddOpcode( "PRINT#", 0x98, "pR" );
      BASICV2.AddOpcode( "?", 0x99 );
      BASICV2.AddOpcode( "PRINT", 0x99 );
      BASICV2.AddOpcode( "CONT", 0x9A, "cO" );
      BASICV2.AddOpcode( "LIST", 0x9B, "lI" );
      BASICV2.AddOpcode( "CLR", 0x9C, "cL" );
      BASICV2.AddOpcode( "CMD", 0x9D, "cM" );
      BASICV2.AddOpcode( "SYS", 0x9E, "sY" );
      BASICV2.AddOpcode( "OPEN", 0x9F, "oP" );
      BASICV2.AddOpcode( "CLOSE", 0xA0, "clO" );
      BASICV2.AddOpcode( "GET", 0xA1, "gE" );
      BASICV2.AddOpcode( "NEW", 0xA2 );
      BASICV2.AddOpcode( "TAB(", 0xA3, "tA" );
      BASICV2.AddOpcode( "TO", 0xA4 );
      BASICV2.AddOpcode( "FN", 0xA5 );
      BASICV2.AddOpcode( "SPC(", 0xA6, "sP" );
      BASICV2.AddOpcode( "THEN", 0xA7, "tH" );
      BASICV2.AddOpcode( "NOT", 0xA8, "nO" );
      BASICV2.AddOpcode( "STEP", 0xA9, "stE" );
      BASICV2.AddOpcode( "+", 0xAA );
      BASICV2.AddOpcode( "-", 0xAB );
      BASICV2.AddOpcode( "*", 0xAC );
      BASICV2.AddOpcode( "/", 0xAD );
      //BASICV2.AddOpcode( "" + (char)0xee1e, 0xAE );
      BASICV2.AddOpcode( "^", 0xAE );
      BASICV2.AddOpcode( "AND", 0xAF, "aN" );
      BASICV2.AddOpcode( "OR", 0xB0 );
      BASICV2.AddOpcode( ">", 0xB1 );
      BASICV2.AddOpcode( "=", 0xB2 );
      BASICV2.AddOpcode( "<", 0xB3 );
      BASICV2.AddOpcode( "SGN", 0xB4, "sG" );
      BASICV2.AddOpcode( "INT", 0xB5 );
      BASICV2.AddOpcode( "ABS", 0xB6, "aB" );
      BASICV2.AddOpcode( "USR", 0xB7, "uS" );
      BASICV2.AddOpcode( "FRE", 0xB8, "fE" );
      BASICV2.AddOpcode( "POS", 0xB9 );
      BASICV2.AddOpcode( "SQR", 0xBA, "sQ" );
      BASICV2.AddOpcode( "RND", 0xBB, "rN" );
      BASICV2.AddOpcode( "LOG", 0xBC );
      BASICV2.AddOpcode( "EXP", 0xBD, "eX" );
      BASICV2.AddOpcode( "COS", 0xBE );
      BASICV2.AddOpcode( "SIN", 0xBF, "sI" );
      BASICV2.AddOpcode( "TAN", 0xC0 );
      BASICV2.AddOpcode( "ATN", 0xC1, "aT" );
      BASICV2.AddOpcode( "PEEK", 0xC2, "pE" );
      BASICV2.AddOpcode( "LEN", 0xC3 );
      BASICV2.AddOpcode( "STR$", 0xC4, "stR" );
      BASICV2.AddOpcode( "VAL", 0xC5, "vA" );
      BASICV2.AddOpcode( "ASC", 0xC6, "aS" );
      BASICV2.AddOpcode( "CHR$", 0xC7, "cH" );
      BASICV2.AddOpcode( "LEFT$", 0xC8, "leF" );
      BASICV2.AddOpcode( "RIGHT$", 0xC9, "rI" );
      BASICV2.AddOpcode( "MID$", 0xCA, "mI" );
      //AddOpcode( "GO", 0xCB );

      // C64Studio extension
      BASICV2.AddExOpcode( "LABEL", 0xF0 );
    }



    public void Clear()
    {
      ExOpcodes.Clear();
      Opcodes.Clear();
      OpcodesFromByte.Clear();
    }



    public void AddOpcode( string Opcode, int ByteValue )
    {
      var opcode = new Opcode( Opcode, ByteValue );
      Opcodes[Opcode] = opcode;
      OpcodesFromByte[(ushort)ByteValue] = opcode;
    }



    public void AddOpcode( string Opcode, int ByteValue, string ShortCut )
    {
      var opcode = new Opcode( Opcode, ByteValue, ShortCut );
      Opcodes[Opcode] = opcode;
      OpcodesFromByte[(ushort)ByteValue] = opcode;
    }



    public void AddExOpcode( string Opcode, int ByteValue )
    {
      ExOpcodes[Opcode] = new Opcode( Opcode, ByteValue );
    }



    public static Dialect ReadBASICDialect( string File, out string ErrorMessage )
    {
      ErrorMessage = "";
      var dialect = new Dialect();
      using ( var reader = new GR.IO.BinaryReader( File ) )
      {
        string    line;
        bool      firstLine = true;
        int       lineIndex = 0;
        bool      exOpcodes = false;

        while ( reader.ReadLine( out line ) )
        {
          ++lineIndex;
          line = line.Trim();
          if ( ( string.IsNullOrEmpty( line ) )
          ||   ( line.StartsWith( "#" ) ) )
          {
            continue;
          }
          // skip header
          if ( firstLine )
          {
            firstLine = false;
            continue;
          }
          if ( line == "ExOpcodes" )
          {
            exOpcodes = true;
            continue;
          }

          string[] parts = line.Split( ';' );
          if ( parts.Length != 3 )
          {
            ErrorMessage = "Invalid BASIC format file '" + File + "', expected three columns in line " + lineIndex;
            return null;
          }
          if ( exOpcodes )
          {
            dialect.AddExOpcode( parts[0], GR.Convert.ToI32( parts[1], 16 ) );
          }
          else
          {
            dialect.AddOpcode( parts[0], GR.Convert.ToI32( parts[1], 16 ), parts[2] );
          }
        }
      }
      dialect.Name = System.IO.Path.GetFileNameWithoutExtension( File );

      return dialect;
    }



  }
}
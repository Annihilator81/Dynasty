using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynasty.Entités
{
    public class Joueur : Personnage
    {
          public KeyboardState NewKeyBoardState;
          public KeyboardState OldkeyBoardState;
          public KeyboardState NewKeyBoardStateAttak;
          public KeyboardState OldKeyBoardStateAttak;
          public TimeSpan Time;
          public bool IsAttacking;
          public bool BeginAttacking;
          public enum Direction
          {
              Haut,
              Bas,
              Droite,
              Gauche
          }
          Direction myDirection; // dédikass à sexion d'hassault
          public Joueur(string nom, int vie, int force, int vitesse, int posX, int posY) 
              : base(nom, vie, force, vitesse, posX, posY)
          {
              Nom = nom;
              RectangleDestination = new Rectangle(posX, posY, 32, 32);
              BeginAttacking = true;
              IsAttacking = false;

              myDirection = Direction.Bas;
          }

          public void Attaquer(GameTime gametime)
          {
              NewKeyBoardStateAttak = Keyboard.GetState();
              //Si attaque
              if (NewKeyBoardState.IsKeyDown(Keys.Space) && !OldkeyBoardState.IsKeyUp(Keys.Space))
              {
                  //OK pour l'attaque
                  IsAttacking = true;
                  //En fonction de l'orientation
                  switch (myDirection)
                  {
                      case Direction.Bas:
                          {
                              RectangleDestinationAttak.Y = RectangleDestination.Y + 32;
                              RectangleDestinationAttak.X = RectangleDestination.X;
                              if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 25)
                              {
                                  if (RectangleSourceAttak.X == 96)
                                  {
                                      RectangleSourceAttak.X = 64;
                                      IsAttacking = false;
                                  }
                                  else
                                  {
                                      RectangleSourceAttak.X += 32;
                                  }
                                  Time = gametime.TotalGameTime;
                              }
                              break;

                          }
                      case Direction.Droite:
                          {
                              RectangleDestinationAttak.X = RectangleDestination.X + 32;
                              RectangleDestinationAttak.Y = RectangleDestination.Y;
                              if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 25)
                              {
                                  if (RectangleSourceAttak.X == 32)
                                  {
                                      RectangleSourceAttak.X = 0;
                                      IsAttacking = false;
                                  }
                                  else
                                  {
                                      RectangleSourceAttak.X += 32;
                                  }
                                  Time = gametime.TotalGameTime;
                              }
                              break;
                          }
                      case Direction.Haut:
                          {
                              RectangleDestinationAttak.X = RectangleDestination.X;
                              RectangleDestinationAttak.Y = RectangleDestination.Y - 32;
                              if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 25)
                              {
                                  if (RectangleSourceAttak.X == 160)
                                  {
                                      RectangleSourceAttak.X = 128;
                                      IsAttacking = false;
                                  }
                                  else
                                  {
                                      RectangleSourceAttak.X += 32;
                                  }
                                  Time = gametime.TotalGameTime;
                              }
                              break;
                          }
                      case Direction.Gauche:
                          {
                              RectangleDestinationAttak.X = RectangleDestination.X - 32;
                              RectangleDestinationAttak.Y = RectangleDestination.Y;
                              if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 25)
                              {
                                  if (RectangleSourceAttak.X == 224)
                                  {
                                      RectangleSourceAttak.X = 192;
                                      IsAttacking = false;
                                  }
                                  else
                                  {
                                      RectangleSourceAttak.X += 32;
                                  }
                                  Time = gametime.TotalGameTime;
                              }
                              break;
                          }
                  }
              }
              OldKeyBoardStateAttak = NewKeyBoardState;
          }
          public void SeDéplacer(GameTime gametime)
          {
              NewKeyBoardState = Keyboard.GetState();
              if (NewKeyBoardState.IsKeyDown(Keys.Up))
              {
                  myDirection = Direction.Haut;
                  RectangleDestination.Y -= 3;
                  if (OldkeyBoardState.IsKeyDown(Keys.Up))
                  {
                      if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 120)
                      {
                          RectangleSource.X = (RectangleSource.X >= 32) ? 0 : RectangleSource.X + RectangleSource.Width;
                          Time = gametime.TotalGameTime;
                      }
                  }
                  else
                  {
                      RectangleSource.X = 0;
                      Time = gametime.TotalGameTime;
                  }
              }
              if (NewKeyBoardState.IsKeyDown(Keys.Down))
              {
                  myDirection = Direction.Bas;
                  RectangleDestination.Y += 3;
                  if (OldkeyBoardState.IsKeyDown(Keys.Down))
                  {
                      if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 120)
                      {
                          RectangleSource.X = (RectangleSource.X >= 224) ? 192 : RectangleSource.X + RectangleSource.Width;
                          Time = gametime.TotalGameTime;
                      }
                  }
                  else
                  {
                      RectangleSource.X = 192;
                      Time = gametime.TotalGameTime;
                  }
              }
              if (NewKeyBoardState.IsKeyDown(Keys.Right))
              {
                  myDirection = Direction.Droite;
                  RectangleDestination.X += 3;
                  if (OldkeyBoardState.IsKeyDown(Keys.Right))
                  {
                      if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 120)
                      {
                          RectangleSource.X = (RectangleSource.X >= 96) ? 64 : RectangleSource.X + RectangleSource.Width;
                          Time = gametime.TotalGameTime;
                      }
                  }
                  else
                  {
                      RectangleSource.X = 96;
                      Time = gametime.TotalGameTime;
                  }
              }

              if (NewKeyBoardState.IsKeyDown(Keys.Left))
              {
                  myDirection = Direction.Gauche;
                  RectangleDestination.X -= 3;
                  if (OldkeyBoardState.IsKeyDown(Keys.Left))
                  {
                      if (gametime.TotalGameTime.Subtract(Time).Milliseconds >= 120)
                      {
                          RectangleSource.X = (RectangleSource.X >= 160) ? 128 : RectangleSource.X + RectangleSource.Width;
                          Time = gametime.TotalGameTime;
                      }
                  }
                  else
                  {
                      RectangleSource.X = 128;
                      Time = gametime.TotalGameTime;
                  }
              }
              OldkeyBoardState = NewKeyBoardState;
          }
    }
}

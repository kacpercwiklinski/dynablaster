﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynaBlaster.Class.PlayerScripts;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaBlaster.Class.MapScripts {
    class Bomb : MapObject {

        float timer = 2.5f;
        float upCounter = 0f;
        private Vector2 positionSpacing;
        private int bombRange = 1;
        private Boolean stateChanged = false;
        private Player player;

        public Bomb(Vector2 pos, int bombRange, Player player) : base(pos) {
            positionSpacing = GridManager.getTextureSpacing(Game1.textureManager.bomb.First());
            this.pos = new Vector2(pos.X + positionSpacing.X, pos.Y + positionSpacing.Y);
            this.texture = Game1.textureManager.bomb.First();
            this.bombRange = bombRange;
            this.player = player;
        }

        public override void Update(GameTime gameTime) {
            upCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Animator.animate(gameTime, ref this.texture, Game1.textureManager.bomb, 0.25f, ref upCounter, true);

            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if(timer <= 0f) {
                explode();
                Player.bombCounter--;
                destroyed = true;
            }

            // Make bomb unwalkable when placed
            if (this.boundingBox.Intersects(player.boundingBox) && !this.stateChanged){
                this.walkable = true;
            } else {
                this.walkable = false;
                this.stateChanged = true;
            }

            base.Update(gameTime);
        }

        private void explode() {
            Map.explosions.Add(new Explosion(this.pos, bombRange));
        }
    }

    class Explosion : MapObject {

        int range;
        float counter = 0f;
        public float livingTime = 0.25f; 
        public List<Wing> wings = new List<Wing>();
        public List<Rectangle> boundingBoxes;

        public Explosion(Vector2 pos, int range) : base(pos) {
            this.label = "Explosion";
            this.range = range;
            this.texture = Game1.textureManager.explosionCenter.First();
            setupBoundingBox();

            this.boundingBoxes = new List<Rectangle>();
            this.boundingBoxes.Add(this.boundingBox);

            wings.Add(new Wing(this.pos, Wing.WingSide.Right, this.range, this.boundingBoxes));
            wings.Add(new Wing(this.pos, Wing.WingSide.Left, this.range, this.boundingBoxes));
            wings.Add(new Wing(this.pos, Wing.WingSide.Top, this.range, this.boundingBoxes));
            wings.Add(new Wing(this.pos, Wing.WingSide.Bottom, this.range, this.boundingBoxes));
        }

        public override void Update(GameTime gameTime) {
            handleTimers(gameTime);

            //Animate center of explosion
            Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionCenter, 0.0625f, ref counter, true);

            // Update each wing state
            wings.ForEach(wing => wing.Update(gameTime));

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            wings.ForEach(wing => wing.Draw(spriteBatch));

            // Draw bounding boxes in debug mode
            if (Game1.debugMode) {
                this.boundingBoxes.ForEach(boundingBox => {
                    LineBatch.drawBoundingBox(boundingBox, spriteBatch);
                });
            }

            base.Draw(spriteBatch);
        }

        private void handleTimers(GameTime gameTime) {
            counter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            livingTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public class Wing {
            public enum WingSide { Left, Right, Top, Bottom }

            WingSide wingSide;
            Vector2 centerOfExplosion;
            int range;
            Vector2 parentPos;
            public List<WingPart> wingParts = new List<WingPart>();


            public Wing(Vector2 parentPos, WingSide wingSide, int range, List<Rectangle> parentBoundingBoxes) {
                this.parentPos = new Vector2(parentPos.X,parentPos.Y);
                centerOfExplosion = new Vector2(parentPos.X + Game1.textureManager.explosionCenter.First().Width/2, parentPos.Y + Game1.textureManager.explosionCenter.First().Height / 2);
                this.wingSide = wingSide;
                this.range = range;

                if(wingSide == WingSide.Right) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X + i * 32, this.centerOfExplosion.Y), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X + i * 32, parentPos.Y), "ExplosionRightEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X + i * 32,(int) parentPos.Y, 32,32));
                            break;
                        } else if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X + i * 32, this.centerOfExplosion.Y), "Dirt")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X + i * 32, parentPos.Y), "ExplosionRightEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X + i * 32, (int)parentPos.Y, 32, 32));
                            Vector2 blockPos = GridManager.GetOnGridPosition(this.centerOfExplosion.X + i * 32, this.centerOfExplosion.Y);
                            if(Map.blocks[(int)blockPos.X, (int)blockPos.Y].label.Equals("Dirt")) {
                                Dirt tempDirt = (Dirt)Map.blocks[(int)blockPos.X, (int)blockPos.Y];
                                tempDirt.startDestroyAnimation = true;
                            }
                            break;
                        }
                        if (i == range) {
                                wingParts.Add(new WingPart(new Vector2(parentPos.X + i * 32, parentPos.Y), "ExplosionRightEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X + i * 32, (int)parentPos.Y, 32, 32));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X + i * 32, parentPos.Y), "ExplosionHorizontalCenter"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X + i * 32, (int)parentPos.Y, 32, 32));
                        }
                    }
                }else if (wingSide == WingSide.Left) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X - i * 32, this.centerOfExplosion.Y), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X - i * 32, parentPos.Y), "ExplosionLeftEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X - i * 32, (int)parentPos.Y, 32, 32));
                            break;
                        } else if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X - i * 32, this.centerOfExplosion.Y), "Dirt")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X - i * 32, parentPos.Y), "ExplosionLeftEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X - i * 32, (int)parentPos.Y, 32, 32));
                            Vector2 blockPos = GridManager.GetOnGridPosition(this.centerOfExplosion.X - i * 32, this.centerOfExplosion.Y);
                            if (Map.blocks[(int)blockPos.X, (int)blockPos.Y].label.Equals("Dirt")) {
                                Dirt tempDirt = (Dirt)Map.blocks[(int)blockPos.X, (int)blockPos.Y];
                                tempDirt.startDestroyAnimation = true;
                            }
                            break;
                        }
                        if (i == range) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X - i * 32, parentPos.Y), "ExplosionLeftEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X - i * 32, (int)parentPos.Y, 32, 32));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X - i * 32, parentPos.Y), "ExplosionHorizontalCenter"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X - i * 32, (int)parentPos.Y, 32, 32));
                        }
                    }
                } else if (wingSide == WingSide.Top) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X, this.centerOfExplosion.Y - i * 32), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y - i * 32), "ExplosionTopEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y - i * 32, 32, 32));
                            break;
                        } else if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X, this.centerOfExplosion.Y - i * 32), "Dirt")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y - i * 32), "ExplosionTopEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y - i * 32, 32, 32));
                            Vector2 blockPos = GridManager.GetOnGridPosition(this.centerOfExplosion.X, this.centerOfExplosion.Y - i * 32);
                            if (Map.blocks[(int)blockPos.X, (int)blockPos.Y].label.Equals("Dirt")) {
                                Dirt tempDirt = (Dirt)Map.blocks[(int)blockPos.X, (int)blockPos.Y];
                                tempDirt.startDestroyAnimation = true;
                            }
                            break;
                        }
                        if (i == range) {
                            wingParts.Add(new WingPart(new Vector2(this.parentPos.X , this.parentPos.Y - i * 32), "ExplosionTopEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y - i * 32, 32, 32));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(this.parentPos.X , this.parentPos.Y - i * 32), "ExplosionVerticalCenter"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y - i * 32, 32, 32));
                        }
                    }
                } else if (wingSide == WingSide.Bottom) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X, this.centerOfExplosion.Y + i * 32), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y + i * 32), "ExplosionBottomEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y + i * 32, 32, 32));
                            break;
                        } else if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X, this.centerOfExplosion.Y + i * 32), "Dirt")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y + i * 32), "ExplosionBottomEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y + i * 32, 32, 32));
                            Vector2 blockPos = GridManager.GetOnGridPosition(this.centerOfExplosion.X, this.centerOfExplosion.Y + i * 32);
                            if (Map.blocks[(int)blockPos.X, (int)blockPos.Y].label.Equals("Dirt")) {
                                Dirt tempDirt = (Dirt)Map.blocks[(int)blockPos.X, (int)blockPos.Y];
                                tempDirt.startDestroyAnimation = true;
                            }
                            break;
                        }
                        if (i == range) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y + i * 32), "ExplosionBottomEnd"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y + i * 32, 32, 32));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y + i * 32), "ExplosionVerticalCenter"));
                            parentBoundingBoxes.Add(new Rectangle((int)parentPos.X, (int)parentPos.Y + i * 32, 32, 32));
                        }
                    }
                }
            }

            public void Update(GameTime gameTime) {
                wingParts.ForEach(part => part.Update(gameTime));
            }

            public void Draw(SpriteBatch spriteBatch) {
                wingParts.ForEach(part => part.Draw(spriteBatch));
            }


            public class WingPart {
                Vector2 pos;
                String partLabel;

                Texture2D texture;
                public float animatorCounter = 0f;
                private float animationFrameTime = 0.0625f;

                public WingPart(Vector2 pos, String partLabel) {
                    this.partLabel = partLabel;
                    this.pos = pos;

                    if (partLabel.Equals("ExplosionHorizontalCenter")) {
                        this.texture = Game1.textureManager.explosionHorizontalCenter.First();
                    }else if (partLabel.Equals("ExplosionRightEnd")) {
                        this.texture = Game1.textureManager.explosionRightEnd.First();
                    } else if (partLabel.Equals("ExplosionLeftEnd")) {
                        this.texture = Game1.textureManager.explosionLeftEnd.First();
                    } else if (partLabel.Equals("ExplosionVerticalCenter")) {
                        this.texture = Game1.textureManager.explosionVerticalCenter.First();
                    } else if (partLabel.Equals("ExplosionTopEnd")) {
                        this.texture = Game1.textureManager.explosionTopEnd.First();
                    } else if (partLabel.Equals("ExplosionBottomEnd")) {
                        this.texture = Game1.textureManager.explosionBottomEnd.First();
                    }
                }

                public void Draw(SpriteBatch spriteBatch) {
                    spriteBatch.Draw(this.texture, this.pos, Color.White);
                }

                public void Update(GameTime gameTime) {
                    animatorCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (partLabel.Equals("ExplosionHorizontalCenter")) {
                        Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionHorizontalCenter, animationFrameTime, ref animatorCounter, true);
                    } else if (partLabel.Equals("ExplosionRightEnd")) {
                        Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionRightEnd, animationFrameTime, ref animatorCounter, true);
                    } else if (partLabel.Equals("ExplosionLeftEnd")) {
                        Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionLeftEnd, animationFrameTime, ref animatorCounter, true);
                    } else if (partLabel.Equals("ExplosionVerticalCenter")) {
                        Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionVerticalCenter, animationFrameTime, ref animatorCounter, true);
                    } else if (partLabel.Equals("ExplosionTopEnd")) {
                        Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionTopEnd, animationFrameTime, ref animatorCounter, true);
                    } else if (partLabel.Equals("ExplosionBottomEnd")) {
                        Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionBottomEnd, animationFrameTime, ref animatorCounter, true);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaBlaster.Class.MapScripts {
    class Bomb : MapObject {

        float timer = 2.5f;
        float upCounter = 0f;
        public bool exploded = false;
        private Vector2 positionSpacing;
        private int bombRange = 5;

        public Bomb(Vector2 pos) : base(pos) {
            positionSpacing = GridManager.getTextureSpacing(Game1.textureManager.bomb.First());
            this.pos = new Vector2(pos.X + positionSpacing.X, pos.Y + positionSpacing.Y);
            this.texture = Game1.textureManager.bomb.First();
        }

        public override void Update(GameTime gameTime) {
            upCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Animator.animate(gameTime, ref this.texture, Game1.textureManager.bomb, 1f, ref upCounter, true);

            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if(timer <= 0f) {
                explode();
                exploded = true;
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
        public float livingTime = 0.5f; //0.5f;
        public List<Wing> wings = new List<Wing>();


        public Explosion(Vector2 pos, int range) : base(pos) {
            this.label = "Explosion";
            this.range = range;
            this.texture = Game1.textureManager.explosionCenter.First();
            setupBoundingBox();

            wings.Add(new Wing(this.pos, Wing.WingSide.Right, this.range));
            wings.Add(new Wing(this.pos, Wing.WingSide.Left, this.range));
            wings.Add(new Wing(this.pos, Wing.WingSide.Top, this.range));
            wings.Add(new Wing(this.pos, Wing.WingSide.Bottom, this.range));
        }

        public override void Update(GameTime gameTime) {
            handleTimers(gameTime);

            Animator.animate(gameTime, ref this.texture, Game1.textureManager.explosionCenter, 0.125f, ref counter, true);

            wings.ForEach(wing => wing.Update(gameTime));

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            wings.ForEach(wing => wing.Draw(spriteBatch));

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


            public Wing(Vector2 parentPos, WingSide wingSide, int range) {
                this.parentPos = new Vector2(parentPos.X,parentPos.Y);
                centerOfExplosion = new Vector2(parentPos.X + Game1.textureManager.explosionCenter.First().Width/2, parentPos.Y + Game1.textureManager.explosionCenter.First().Height / 2);
                this.wingSide = wingSide;
                this.range = range;

                if(wingSide == WingSide.Right) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X + i * 32, this.centerOfExplosion.Y), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X + i * 32, parentPos.Y), "ExplosionRightEnd"));
                            break;
                        }
                        if (i == range) {
                                wingParts.Add(new WingPart(new Vector2(parentPos.X + i * 32, parentPos.Y), "ExplosionRightEnd"));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X + i * 32, parentPos.Y), "ExplosionHorizontalCenter"));
                        }
                    }
                }else if (wingSide == WingSide.Left) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X - i * 32, this.centerOfExplosion.Y), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X - i * 32, parentPos.Y), "ExplosionLeftEnd"));
                            break;
                        }
                        if (i == range) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X - i * 32, parentPos.Y), "ExplosionLeftEnd"));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X - i * 32, parentPos.Y), "ExplosionHorizontalCenter"));
                        }
                    }
                } else if (wingSide == WingSide.Top) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X, this.centerOfExplosion.Y - i * 32), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y - i * 32), "ExplosionTopEnd"));
                            break;
                        }
                        if (i == range) {
                            wingParts.Add(new WingPart(new Vector2(this.parentPos.X , this.parentPos.Y - i * 32), "ExplosionTopEnd"));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(this.parentPos.X , this.parentPos.Y - i * 32), "ExplosionVerticalCenter"));
                        }
                    }
                } else if (wingSide == WingSide.Bottom) {
                    for (int i = 1; i <= range; i++) {
                        if (GridManager.checkIfBlockExist(new Vector2(this.centerOfExplosion.X, this.centerOfExplosion.Y + (i * 32)), "Block Wall Explosion")) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y + i * 32), "ExplosionBottomEnd"));
                            break;
                        }
                        if (i == range) {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y + i * 32), "ExplosionBottomEnd"));
                        } else {
                            wingParts.Add(new WingPart(new Vector2(parentPos.X, parentPos.Y + i * 32), "ExplosionVerticalCenter"));
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
                private float animationFrameTime = 0.125f;

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

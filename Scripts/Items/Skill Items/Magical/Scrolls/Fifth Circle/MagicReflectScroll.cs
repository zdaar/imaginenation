//needed for custom scrolls

namespace Server.Items
{
    public class MagicReflectScroll : SpellScroll
    {
        public override int ManaCost { get { return 16; } } //Loki edit: was 16 //Zdar edit : BECAUSE IT WAS XUO YOU FAG

        [Constructable]
        public MagicReflectScroll()
            : this(1)
        {
        }

        [Constructable]
        public MagicReflectScroll(int amount)
            : base(35, 0x1F50, amount)
        {
            //Name = "Magic Reflect Scroll";
            Weight = 0.0;
        }

        public MagicReflectScroll(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        
        }
        
        public override void OnDoubleClick(Mobile from)//XUO SCROLLS
        {
            if (!Sphere.CanUse(from, this))
                return;

            if (from.Mana < 11)
            {
                from.LastKiller = from;
                from.Kill();
            }
            else
            {
                from.Mana -= 10;
                
                base.OnDoubleClick(from);
            }
        }
    }
}
namespace Server.Items
{
    public class GreaterHealScroll : SpellScroll
    {
        public override int ManaCost { get { return 11; } }

        [Constructable]
        public GreaterHealScroll()
            : this(1)
        {
        }

        [Constructable]
        public GreaterHealScroll(int amount)
            : base(28, 0x1F49, amount)
        {
            //Name = "Greater Heal";
            Weight = 0.0;
        }

        public GreaterHealScroll(Serial serial)
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

            if (from.Mana < 21)
            {
                from.LastKiller = from;
                from.Kill();
            }
            else
            {
                from.Mana -= 20;
            /*  from.PlaySound(from.GetHurtSound());

                if (!from.Mounted)
                    from.Animate(20, 5, 1, true, false, 0);
                else
                    from.Animate(29, 5, 1, true, false, 0);
            */
                base.OnDoubleClick(from);
            }
        }
    }
}
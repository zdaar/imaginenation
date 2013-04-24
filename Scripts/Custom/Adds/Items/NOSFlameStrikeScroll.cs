namespace Server.Items
{
    public class NOSFlameStrikeScroll : SpellScroll
    {
        public override int ManaCost { get { return 25; } } //Loki edit

        [Constructable]
        public NOSFlameStrikeScroll()
            : this(1)
        {
        }

        [Constructable]
        public NOSFlameStrikeScroll(int amount)
            : base(50, 0x1F5F, amount)//SERIAL ?
        {
            Name = "(NOS)FlameStrike";
            Weight = 0.0;
        }

        public NOSFlameStrikeScroll(Serial serial)
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

        public override void OnDoubleClick(Mobile from)
        {
            if (!Sphere.CanUse(from, this))
                return;

            if (from.Mana < 16)
            {
                from.LastKiller = from;
                from.Kill();
            }
            else
            {
                from.Mana -= 15;
               /* from.PlaySound(from.GetHurtSound());

                if (!from.Mounted)
                    from.Animate(20, 5, 1, true, false, 0);
                else
                    from.Animate(29, 5, 1, true, false, 0);*/

                base.OnDoubleClick(from);
            }
        }
        /*
        public bool Transform(Mobile from, ScrollTransformer transformer)
        {
            if (Deleted || !from.CanSee(this)) return false;

            base.ScissorHelper(from, new FlamestrikeScrollNOS(), 1);

            return true;
        }*/
    }
}

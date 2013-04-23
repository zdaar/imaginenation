using Server.Mobiles;
using Server.Commands;
using Server.Network;
namespace Server.Items
{
    public class RefreshStone : Item
    {
        private int m_Price = 0;

        [CommandProperty(AccessLevel.Seer)]
        public int Price
        {
            get { return m_Price; }
            set { m_Price = value; }
        }

        [Constructable]
        public RefreshStone()
            : base(0xED5)
        {
            Name = "Refresh Stone";
            Movable = false;
            Hue = 1159;
        }

        public RefreshStone(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.Alive && from is PlayerMobile)
            {
                ((PlayerMobile)from).ForceResurrect();
                CommandLogging.WriteLine(from, "Refreshing and resurrecting " + from.Name);
            }
            else if (!from.Alive)
            {
                from.Resurrect();
                CommandLogging.WriteLine(from, "Refreshing and resurrecting " + from.Name);
            }

            CommandLogging.WriteLine(from, "Refreshing but not resurrecting) " + from.Name);

            from.PublicOverheadMessage(MessageType.Regular, from.SpeechHue, true, "I've been refreshed.");

            from.Hits = from.HitsMax;
            from.Stam = from.StamMax;
            from.Mana = from.ManaMax;
            from.CurePoison(from);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version 

            writer.Write(m_Price);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 1)
                m_Price = reader.ReadInt();
        }
    }
}
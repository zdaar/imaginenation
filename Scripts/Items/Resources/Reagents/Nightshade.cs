using System;

namespace Server.Items
{
	public class Nightshade : BaseReagent, ICommodity
	{
        int ICommodity.DescriptionNumber { get { return LabelNumber; } }
        bool ICommodity.IsDeedable { get { return true; } }

        public override int PotionGroupIndex
        {
            get { return 5; }
        } 

		[Constructable]
		public Nightshade() : this( 1 )
		{
		}

		[Constructable]
		public Nightshade( int amount ) : base( 0xF88, amount )
		{
            Weight = 0.0;
		}

		public Nightshade( Serial serial ) : base( serial )
		{
		}

		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
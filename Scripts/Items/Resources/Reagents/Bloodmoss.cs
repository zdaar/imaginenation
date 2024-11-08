using System;

namespace Server.Items
{
	public class Bloodmoss : BaseReagent, ICommodity
	{
        public override int PotionGroupIndex
        {
            get{ return 1; }
        } 

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }
        bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public Bloodmoss() : this( 1 )
		{
		}

		[Constructable]
		public Bloodmoss( int amount ) : base( 0xF7B, amount )
		{
            //Name = "Blood Moss";
            Weight = 0.0;
		}

		public Bloodmoss( Serial serial ) : base( serial )
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
/* https://trueuo.com Home to the Heritage shard.*/
using Server.Engines.BulkOrders;

namespace Server.Items
{
    public class BulkOrderPointDeed : Item
    {
        private const int _Points = 100; // Set your points here.
        private const BODType _CraftSkill = BODType.Smith; // Set skill type here. Example: BODType.Smith

        [Constructable]
        public BulkOrderPointDeed()
            : base(0x14F0)
        {
            Name = "Bulk Order Point Deed";
            LootType = LootType.Blessed;
        }

        public BulkOrderPointDeed(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                BulkOrderSystem.SetPoints(from, _CraftSkill, _Points);

                from.SendMessage($"{_Points} points have been added to your character's {_CraftSkill} balance.");

                Delete();
            }
            else
            {
                from.SendLocalizedMessage(1062334); // This item must be in your backpack to be used.
            }
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add($"Worth {_Points} {_CraftSkill} Points"); 

        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}

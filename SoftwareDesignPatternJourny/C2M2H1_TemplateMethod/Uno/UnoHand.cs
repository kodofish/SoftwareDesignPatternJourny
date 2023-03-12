namespace C2M2H1_TemplateMethod.Uno
{
    using Framework;

    public class UnoHand : HandBase<UnoCard>
    {
        public override UnoCard DrawCard(UnoCard? card = default)
        {
            var availableCard = this.FirstOrDefault(it => it.CompareTo(card) == 0);

            return availableCard == null
                       ? new EmptyUnoCard()
                       : base.DrawCard(availableCard);
        }
    }
}
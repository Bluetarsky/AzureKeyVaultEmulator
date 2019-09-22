namespace KeyVaultEmulator.Data
{
    public class SecretTag
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public int FkSecretKey { get; set; }

        public virtual Secret Secret { get; set; }
    }
}

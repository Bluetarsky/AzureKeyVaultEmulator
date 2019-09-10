namespace KeyVaultEmulator.Data
{
    public class SecretTag
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public int FkSecretKey { get; set; }

        public virtual Secret Secret { get; set; }
    }
}

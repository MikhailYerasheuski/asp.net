//1. Get the bytes
    byte[] orderBytes = System.Text.Encoding.UTF8.GetBytes( orderData);
    
    try
    {
        using (var baout = new System.IO.MemoryStream())
        {
            //2. GZIP bytes
            using (var zip = new System.IO.Compression.GZipStream(baout, System.IO.Compression.CompressionMode.Compress))
            {
                zip.Write(orderBytes, 0, orderBytes.Length);
            }                    
            //3. Encode Base64         
            orderData = System.Convert.ToBase64String(baout.ToArray());
        }
    }
    catch (System.Exception e)
    {
        throw new System.Exception("Unable to create zipped and Base64 encoded orderData due to:" + e.Message);
}

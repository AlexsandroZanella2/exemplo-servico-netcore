using Exemplo.ServicoNetCore.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exemplo.ServicoNetCore.DataAccess.Entities
{
    public class LojaXML
    {
        [XmlElement("CNPJ")]
        public string Cnpj { get; set; }
        
        //[XmlArray("dadosMovimento")]
        //[XmlArrayItem("produto")]

        //public List<ProdutoXML> Produto { get; set; }
    }
}
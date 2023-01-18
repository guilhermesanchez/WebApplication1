using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPesquisa
{

  public partial class PesquisaDTO
  {
    [JsonProperty("took")]
    public long Took { get; set; }

    [JsonProperty("timed_out")]
    public bool TimedOut { get; set; }

    [JsonProperty("_shards")]
    public Shards Shards { get; set; }

    [JsonProperty("hits")]
    public Hits Hits { get; set; }
  }

  public partial class Hits
  {
    [JsonProperty("total")]
    public Total Total { get; set; }

    [JsonProperty("max_score")]
    public double MaxScore { get; set; }

    [JsonProperty("hits")]
    public Hit[] HitsHits { get; set; }
  }

  public partial class Hit
  {
    [JsonProperty("_index")]
    public string Index { get; set; }

    [JsonProperty("_type")]
    public string Type { get; set; }

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("_score")]
    public double Score { get; set; }

    [JsonProperty("_source")]
    public Source Source { get; set; }
  }

  public partial class Source
  {
    [JsonProperty("estalecimento_noFantasia")]
    public string EstalecimentoNoFantasia { get; set; }

    [JsonProperty("vacina_lote")]
    public string VacinaLote { get; set; }

    [JsonProperty("estabelecimento_municipio_codigo")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long EstabelecimentoMunicipioCodigo { get; set; }

    [JsonProperty("estabelecimento_valor")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long EstabelecimentoValor { get; set; }

    [JsonProperty("vacina_nome")]
    public string VacinaNome { get; set; }

    [JsonProperty("ds_condicao_maternal")]
    public string DsCondicaoMaternal { get; set; }

    [JsonProperty("paciente_endereco_coPais")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long PacienteEnderecoCoPais { get; set; }

    [JsonProperty("@version")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Version { get; set; }

    [JsonProperty("document_id")]
    public string DocumentId { get; set; }

    [JsonProperty("paciente_nacionalidade_enumNacionalidade")]
    public string PacienteNacionalidadeEnumNacionalidade { get; set; }

    [JsonProperty("vacina_categoria_codigo")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long VacinaCategoriaCodigo { get; set; }

    [JsonProperty("vacina_fabricante_referencia")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long VacinaFabricanteReferencia { get; set; }

    [JsonProperty("paciente_id")]
    public string PacienteId { get; set; }

    [JsonProperty("paciente_idade")]
    public long PacienteIdade { get; set; }

    [JsonProperty("vacina_descricao_dose")]
    public string VacinaDescricaoDose { get; set; }

    [JsonProperty("paciente_endereco_coIbgeMunicipio")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long PacienteEnderecoCoIbgeMunicipio { get; set; }

    [JsonProperty("vacina_grupoAtendimento_codigo")]
    public string VacinaGrupoAtendimentoCodigo { get; set; }

    [JsonProperty("data_importacao_datalake")]
    public DateTimeOffset DataImportacaoDatalake { get; set; }

    [JsonProperty("paciente_racaCor_codigo")]
    public string PacienteRacaCorCodigo { get; set; }

    [JsonProperty("estabelecimento_uf")]
    public string EstabelecimentoUf { get; set; }

    [JsonProperty("estabelecimento_razaoSocial")]
    public string EstabelecimentoRazaoSocial { get; set; }

    [JsonProperty("vacina_numDose")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long VacinaNumDose { get; set; }

    [JsonProperty("@timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonProperty("sistema_origem")]
    public string SistemaOrigem { get; set; }

    [JsonProperty("paciente_dataNascimento")]
    public DateTimeOffset PacienteDataNascimento { get; set; }

    [JsonProperty("paciente_endereco_uf")]
    public string PacienteEnderecoUf { get; set; }

    [JsonProperty("vacina_fabricante_nome")]
    public string VacinaFabricanteNome { get; set; }

    [JsonProperty("paciente_endereco_cep")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long PacienteEnderecoCep { get; set; }

    [JsonProperty("id_sistema_origem")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long IdSistemaOrigem { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("paciente_endereco_nmPais")]
    public string PacienteEnderecoNmPais { get; set; }

    [JsonProperty("vacina_categoria_nome")]
    public string VacinaCategoriaNome { get; set; }

    [JsonProperty("paciente_endereco_nmMunicipio")]
    public string PacienteEnderecoNmMunicipio { get; set; }

    [JsonProperty("estabelecimento_municipio_nome")]
    public string EstabelecimentoMunicipioNome { get; set; }

    [JsonProperty("vacina_codigo")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long VacinaCodigo { get; set; }

    [JsonProperty("paciente_enumSexoBiologico")]
    public string PacienteEnumSexoBiologico { get; set; }

    [JsonProperty("dt_deleted")]
    public DateTimeOffset DtDeleted { get; set; }

    [JsonProperty("co_condicao_maternal")]
    public long CoCondicaoMaternal { get; set; }

    [JsonProperty("vacina_grupoAtendimento_nome")]
    public string VacinaGrupoAtendimentoNome { get; set; }

    [JsonProperty("paciente_racaCor_valor")]
    public string PacienteRacaCorValor { get; set; }

    [JsonProperty("vacina_dataAplicacao")]
    public DateTimeOffset VacinaDataAplicacao { get; set; }

    [JsonProperty("data_importacao_rnds")]
    public DateTimeOffset DataImportacaoRnds { get; set; }
  }

  public partial class Total
  {
    [JsonProperty("value")]
    public long Value { get; set; }

    [JsonProperty("relation")]
    public string Relation { get; set; }
  }

  public partial class Shards
  {
    [JsonProperty("total")]
    public long Total { get; set; }

    [JsonProperty("successful")]
    public long Successful { get; set; }

    [JsonProperty("skipped")]
    public long Skipped { get; set; }

    [JsonProperty("failed")]
    public long Failed { get; set; }
  }

  internal static class Converter
  {
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
      MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
      DateParseHandling = DateParseHandling.None,
      Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
  }

  internal class ParseStringConverter : JsonConverter
  {
    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null) return null;
      var value = serializer.Deserialize<string>(reader);
      long l;
      if (Int64.TryParse(value, out l))
      {
        return l;
      }
      throw new Exception("Cannot unmarshal type long");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
      if (untypedValue == null)
      {
        serializer.Serialize(writer, null);
        return;
      }
      var value = (long)untypedValue;
      serializer.Serialize(writer, value.ToString());
      return;
    }

    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
  }
  }

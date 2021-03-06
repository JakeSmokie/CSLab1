// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: maths.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbr = global::Google.Protobuf.Reflection;
namespace Labs
{

    /// <summary>Holder for reflection information generated from maths.proto</summary>
    public static partial class MathsReflection {

    #region Descriptor
    /// <summary>File descriptor for maths.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MathsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgttYXRocy5wcm90bxIEbGFicyImCglBcmd1bWVudHMSCgoCSUQYASABKAkS",
            "DQoFSW5wdXQYAiABKAEiFwoGUmVzdWx0Eg0KBVZhbHVlGAEgASgBMoECCg9N",
            "YXRoc1Byb2NjZXNzb3ISJgoDU2V0Eg8ubGFicy5Bcmd1bWVudHMaDC5sYWJz",
            "LlJlc3VsdCIAEiYKA0ptcBIPLmxhYnMuQXJndW1lbnRzGgwubGFicy5SZXN1",
            "bHQiABImCgNBZGQSDy5sYWJzLkFyZ3VtZW50cxoMLmxhYnMuUmVzdWx0IgAS",
            "JgoDU3ViEg8ubGFicy5Bcmd1bWVudHMaDC5sYWJzLlJlc3VsdCIAEiYKA011",
            "bBIPLmxhYnMuQXJndW1lbnRzGgwubGFicy5SZXN1bHQiABImCgNEaXYSDy5s",
            "YWJzLkFyZ3VtZW50cxoMLmxhYnMuUmVzdWx0IgBiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Labs.Arguments), global::Labs.Arguments.Parser, new[]{ "ID", "Input" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Labs.Result), global::Labs.Result.Parser, new[]{ "Value" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Arguments : pb::IMessage<Arguments> {
    private static readonly pb::MessageParser<Arguments> _parser = new pb::MessageParser<Arguments>(() => new Arguments());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Arguments> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Labs.MathsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Arguments() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Arguments(Arguments other) : this() {
      iD_ = other.iD_;
      input_ = other.input_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Arguments Clone() {
      return new Arguments(this);
    }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private string iD_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ID {
      get { return iD_; }
      set {
        iD_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Input" field.</summary>
    public const int InputFieldNumber = 2;
    private double input_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Input {
      get { return input_; }
      set {
        input_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Arguments);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Arguments other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ID != other.ID) return false;
      if (Input != other.Input) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ID.Length != 0) hash ^= ID.GetHashCode();
      if (Input != 0D) hash ^= Input.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ID);
      }
      if (Input != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Input);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ID);
      }
      if (Input != 0D) {
        size += 1 + 8;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Arguments other) {
      if (other == null) {
        return;
      }
      if (other.ID.Length != 0) {
        ID = other.ID;
      }
      if (other.Input != 0D) {
        Input = other.Input;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            ID = input.ReadString();
            break;
          }
          case 17: {
            Input = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Result : pb::IMessage<Result> {
    private static readonly pb::MessageParser<Result> _parser = new pb::MessageParser<Result>(() => new Result());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Result> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Labs.MathsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Result() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Result(Result other) : this() {
      value_ = other.value_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Result Clone() {
      return new Result(this);
    }

    /// <summary>Field number for the "Value" field.</summary>
    public const int ValueFieldNumber = 1;
    private double value_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Value {
      get { return value_; }
      set {
        value_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Result);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Result other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Value != other.Value) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Value != 0D) hash ^= Value.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Value != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Value);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Value != 0D) {
        size += 1 + 8;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Result other) {
      if (other == null) {
        return;
      }
      if (other.Value != 0D) {
        Value = other.Value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 9: {
            Value = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gRPC/Protos/model.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace PharmacyIntegration.grpc.Protos {
  public static partial class CheckForMedication
  {
    static readonly string __ServiceName = "com.schnabel.schnabel.pswregistration.grpc.CheckForMedication";

    static readonly grpc::Marshaller<global::PharmacyIntegration.grpc.Protos.MessageProto> __Marshaller_com_schnabel_schnabel_pswregistration_grpc_MessageProto = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PharmacyIntegration.grpc.Protos.MessageProto.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PharmacyIntegration.grpc.Protos.MessageResponseProto> __Marshaller_com_schnabel_schnabel_pswregistration_grpc_MessageResponseProto = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PharmacyIntegration.grpc.Protos.MessageResponseProto.Parser.ParseFrom);

    static readonly grpc::Method<global::PharmacyIntegration.grpc.Protos.MessageProto, global::PharmacyIntegration.grpc.Protos.MessageResponseProto> __Method_check = new grpc::Method<global::PharmacyIntegration.grpc.Protos.MessageProto, global::PharmacyIntegration.grpc.Protos.MessageResponseProto>(
        grpc::MethodType.Unary,
        __ServiceName,
        "check",
        __Marshaller_com_schnabel_schnabel_pswregistration_grpc_MessageProto,
        __Marshaller_com_schnabel_schnabel_pswregistration_grpc_MessageResponseProto);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PharmacyIntegration.grpc.Protos.ModelReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for CheckForMedication</summary>
    public partial class CheckForMedicationClient : grpc::ClientBase<CheckForMedicationClient>
    {
      /// <summary>Creates a new client for CheckForMedication</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CheckForMedicationClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CheckForMedication that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CheckForMedicationClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CheckForMedicationClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CheckForMedicationClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::PharmacyIntegration.grpc.Protos.MessageResponseProto check(global::PharmacyIntegration.grpc.Protos.MessageProto request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return check(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::PharmacyIntegration.grpc.Protos.MessageResponseProto check(global::PharmacyIntegration.grpc.Protos.MessageProto request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_check, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::PharmacyIntegration.grpc.Protos.MessageResponseProto> checkAsync(global::PharmacyIntegration.grpc.Protos.MessageProto request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return checkAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::PharmacyIntegration.grpc.Protos.MessageResponseProto> checkAsync(global::PharmacyIntegration.grpc.Protos.MessageProto request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_check, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CheckForMedicationClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CheckForMedicationClient(configuration);
      }
    }

  }
}
#endregion

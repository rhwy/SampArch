<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d0ed9acb-0435-4532-afdd-b5115bc4d562" namespace="SampArch.Presentation.Configuration" xmlSchemaNamespace="SampArch.Presentation.Configuration" assemblyName="SampArch.Presentation.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationElementCollection name="AppKeys" xmlItemName="appKeys" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DefaultKeyValue" />
      </itemType>
    </configurationElementCollection>
    <configurationSection name="SampArch.Core" hasCustomChildElements="true" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="sampArch.Core">
      <elementProperties>
        <elementProperty name="appKeys" isRequired="false" isKey="false" isDefaultCollection="true" xmlName="appKeys" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/AppKeys" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="DefaultKeyValue">
      <attributeProperties>
        <attributeProperty name="Key" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="key" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationSection name="SampArch.Blog" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="sampArch.Blog" />
    <configurationSection name="SampArch.Ideas" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="sampArch.Ideas" />
    <configurationSectionGroup name="SampArch">
      <configurationSectionProperties>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/SampArch.Blog" />
          </containedConfigurationSection>
        </configurationSectionProperty>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/SampArch.Core" />
          </containedConfigurationSection>
        </configurationSectionProperty>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/SampArch.Ideas" />
          </containedConfigurationSection>
        </configurationSectionProperty>
      </configurationSectionProperties>
    </configurationSectionGroup>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>
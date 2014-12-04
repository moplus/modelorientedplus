<CONFIG>
	NAME MDLXmlModel
	NODE SpecificationSource
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
// copy the contents of an M+ xml file to the model
<%%:
var xValue
foreach (XmlNode)
{
	if (XmlNodeName == "Solution")
	{
		foreach (XmlNode)
		{
			if (XmlNodeName == "FeatureList")
			{
				foreach (XmlNode)
				{
					if (XmlNodeName == "Feature")
					{
						// add the feature from the xml
						CurrentFeature = New()
						foreach (XmlNode)
						{
							if (XmlNodeName == "FeatureID")
							{
								foreach (XmlNode)
								{
									CurrentFeature.FeatureID = Value
								}
							}
							if (XmlNodeName == "FeatureName")
							{
								foreach (XmlNode)
								{
									CurrentFeature.FeatureName = Value
								}
							}
							if (XmlNodeName == "Description")
							{
								foreach (XmlNode)
								{
									CurrentFeature.Description = Value
								}
							}
							if (XmlNodeName == "Tags")
							{
								foreach (XmlNode)
								{
									CurrentFeature.Tags = Value
								}
							}
						}
						add(CurrentFeature)
						
						foreach (XmlNode)
						{
							if (XmlNodeName == "EntityList")
							{
								foreach (XmlNode)
								{
									if (XmlNodeName == "Entity")
									{
										// add the entity from the xml
										CurrentEntity = New()
										CurrentEntity.FeatureID = CurrentFeature.FeatureID
										foreach (XmlNode)
										{
											//trace(XmlNodeName)
											if (XmlNodeName == "EntityID")
											{
												foreach (XmlNode)
												{
													CurrentEntity.EntityID = Value
												}
											}
											if (XmlNodeName == "BaseEntityID")
											{
												foreach (XmlNode)
												{
													CurrentEntity.BaseEntityID = Value
												}
											}
											if (XmlNodeName == "EntityName")
											{
												foreach (XmlNode)
												{
													CurrentEntity.EntityName = Value
												}
											}
											if (XmlNodeName == "EntityTypeCode")
											{
												foreach (XmlNode)
												{
													CurrentEntity.EntityTypeCode = Value
												}
											}
											if (XmlNodeName == "IdentifierTypeCode")
											{
												foreach (XmlNode)
												{
													CurrentEntity.IdentifierTypeCode = Value
												}
											}
											if (XmlNodeName == "Description")
											{
												foreach (XmlNode)
												{
													CurrentEntity.Description = Value
												}
											}
											if (XmlNodeName == "Tags")
											{
												foreach (XmlNode)
												{
													CurrentEntity.Tags = Value
												}
											}
										}
										add(CurrentEntity)
										foreach (XmlNode)
										{
											if (XmlNodeName == "PropertyList")
											{
												foreach (XmlNode)
												{
													if (XmlNodeName == "Property")
													{
														// add the property from the xml
														CurrentProperty = New()
														CurrentProperty.EntityID = CurrentEntity.EntityID
														foreach (XmlNode)
														{
															//trace(XmlNodeName)
															if (XmlNodeName == "PropertyID")
															{
																foreach (XmlNode)
																{
																	// trace("Setting PropertyID to: " + Value)
																	CurrentProperty.PropertyID = Value
																}
															}
															if (XmlNodeName == "PropertyName")
															{
																foreach (XmlNode)
																{
																	// trace("Setting PropertyName to: " + Value)
																	CurrentProperty.PropertyName = Value
																}
															}
															if (XmlNodeName == "Order")
															{
																foreach (XmlNode)
																{
																	CurrentProperty.Order = Value
																}
															}
															if (XmlNodeName == "DataTypeCode")
															{
																foreach (XmlNode)
																{
																	CurrentProperty.DataTypeCode = Value
																}
															}
															if (XmlNodeName == "Precision")
															{
																foreach (XmlNode)
																{
																	CurrentProperty.Precision = Value
																}
															}
															if (XmlNodeName == "IsPrimaryKeyMember")
															{
																foreach (XmlNode)
																{
																	CurrentProperty.IsPrimaryKeyMember = Value
																}
															}
															if (XmlNodeName == "IsForeignKeyMember")
															{
																foreach (XmlNode)
																{
																	CurrentProperty.IsForeignKeyMember = Value
																}
															}
															if (XmlNodeName == "IsNullable")
															{
																foreach (XmlNode)
																{
																	CurrentProperty.IsNullable = Value
																}
															}
															if (XmlNodeName == "Description")
															{
																foreach (XmlNode)
																{
																	CurrentEntity.Description = Value
																}
															}
															if (XmlNodeName == "Tags")
															{
																foreach (XmlNode)
																{
																	CurrentEntity.Tags = Value
																}
															}
														}
														add(CurrentProperty)
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}

// go through the document a second time to get the referenced items
foreach (XmlNode)
{
	if (XmlNodeName == "Solution")
	{
		foreach (XmlNode)
		{
			if (XmlNodeName == "FeatureList")
			{
				foreach (XmlNode)
				{
					if (XmlNodeName == "Feature")
					{
						foreach (XmlNode)
						{
							if (XmlNodeName == "EntityList")
							{
								foreach (XmlNode)
								{
									if (XmlNodeName == "Entity")
									{
										// add the entity from the xml
										CurrentEntity = New()
										foreach (XmlNode)
										{
											//trace(XmlNodeName)
											if (XmlNodeName == "EntityID")
											{
												foreach (XmlNode)
												{
													xValue = Value
													with (Entity from Solution.Find(xValue))
													{
														CurrentEntity = Entity
														// trace("Found entity: " + CurrentEntity.EntityName)
													}
												}
											}
										}
										foreach (XmlNode)
										{
											if (XmlNodeName == "CollectionList")
											{
												foreach (XmlNode)
												{
													if (XmlNodeName == "Collection")
													{
														// add the collection from the xml
														CurrentCollection = New()
														CurrentCollection.EntityID = CurrentEntity.EntityID
														foreach (XmlNode)
														{
															//trace(XmlNodeName)
															if (XmlNodeName == "PropertyID")
															{
																foreach (XmlNode)
																{
																	CurrentCollection.PropertyID = Value
																}
															}
															if (XmlNodeName == "CollectionName")
															{
																foreach (XmlNode)
																{
																	CurrentCollection.CollectionName = Value
																}
															}
															if (XmlNodeName == "Order")
															{
																foreach (XmlNode)
																{
																	CurrentCollection.Order = Value
																}
															}
															if (XmlNodeName == "ReferencedEntityID")
															{
																foreach (XmlNode)
																{
																	CurrentCollection.ReferencedEntityID = Value
																}
															}
															if (XmlNodeName == "IsNullable")
															{
																foreach (XmlNode)
																{
																	CurrentCollection.IsNullable = Value
																}
															}
															if (XmlNodeName == "Description")
															{
																foreach (XmlNode)
																{
																	CurrentCollection.Description = Value
																}
															}
															if (XmlNodeName == "Tags")
															{
																foreach (XmlNode)
																{
																	CurrentCollection.Tags = Value
																}
															}
														}
														add(CurrentCollection)
													}
												}
											}
											if (XmlNodeName == "PropertyReferenceList")
											{
												foreach (XmlNode)
												{
													if (XmlNodeName == "PropertyReference")
													{
														// add the property reference from the xml
														CurrentPropertyReference = New()
														CurrentPropertyReference.EntityID = CurrentEntity.EntityID
														foreach (XmlNode)
														{
															//trace(XmlNodeName)
															if (XmlNodeName == "PropertyID")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.PropertyID = Value
																}
															}
															if (XmlNodeName == "PropertyReferenceName")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.PropertyReferenceName = Value
																}
															}
															if (XmlNodeName == "Order")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.Order = Value
																}
															}
															if (XmlNodeName == "ReferencedEntityID")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.ReferencedEntityID = Value
																}
															}
															if (XmlNodeName == "ReferencedPropertyID")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.ReferencedPropertyID = Value
																}
															}
															if (XmlNodeName == "IsNullable")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.IsNullable = Value
																}
															}
															if (XmlNodeName == "Description")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.Description = Value
																}
															}
															if (XmlNodeName == "Tags")
															{
																foreach (XmlNode)
																{
																	CurrentPropertyReference.Tags = Value
																}
															}
														}
														add(CurrentPropertyReference)
														foreach (XmlNode)
														{
															if (XmlNodeName == "PropertyRelationshipList")
															{
																foreach (XmlNode)
																{
																	if (XmlNodeName == "PropertyRelationship")
																	{
																		// add the property relationship from the xml
																		CurrentPropertyRelationship = New()
																		CurrentPropertyRelationship.PropertyID = CurrentPropertyReference.PropertyID
																		foreach (XmlNode)
																		{
																			// trace(XmlNodeName)
																			if (XmlNodeName == "RelationshipID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentPropertyRelationship.RelationshipID = Value
																				}
																			}
																			if (XmlNodeName == "Order")
																			{
																				foreach (XmlNode)
																				{
																					CurrentPropertyRelationship.Order = Value
																				}
																			}
																			if (XmlNodeName == "Description")
																			{
																				foreach (XmlNode)
																				{
																					CurrentPropertyRelationship.Description = Value
																				}
																			}
																			if (XmlNodeName == "Tags")
																			{
																				foreach (XmlNode)
																				{
																					CurrentPropertyRelationship.Tags = Value
																				}
																			}
																		}
																		add(CurrentPropertyRelationship)
																	}
																}
															}
														}
													}
												}
											}
											if (XmlNodeName == "EntityReferenceList")
											{
												foreach (XmlNode)
												{
													if (XmlNodeName == "EntityReference")
													{
														// add the entity reference from the xml
														CurrentEntityReference = New()
														CurrentEntityReference.EntityID = CurrentEntity.EntityID
														foreach (XmlNode)
														{
															//trace(XmlNodeName)
															if (XmlNodeName == "PropertyID")
															{
																foreach (XmlNode)
																{
																	CurrentEntityReference.PropertyID = Value
																}
															}
															if (XmlNodeName == "EntityReferenceName")
															{
																foreach (XmlNode)
																{
																	CurrentEntityReference.EntityReferenceName = Value
																}
															}
															if (XmlNodeName == "Order")
															{
																foreach (XmlNode)
																{
																	CurrentEntityReference.Order = Value
																}
															}
															if (XmlNodeName == "ReferencedEntityID")
															{
																foreach (XmlNode)
																{
																	CurrentEntityReference.ReferencedEntityID = Value
																}
															}
															if (XmlNodeName == "IsNullable")
															{
																foreach (XmlNode)
																{
																	CurrentEntityReference.IsNullable = Value
																}
															}
															if (XmlNodeName == "Description")
															{
																foreach (XmlNode)
																{
																	CurrentEntityReference.Description = Value
																}
															}
															if (XmlNodeName == "Tags")
															{
																foreach (XmlNode)
																{
																	CurrentEntityReference.Tags = Value
																}
															}
														}
														add(CurrentEntityReference)
													}
												}
											}
											if (XmlNodeName == "MethodList")
											{
												foreach (XmlNode)
												{
													if (XmlNodeName == "Method")
													{
														// add the method from the xml
														CurrentMethod = New()
														CurrentMethod.EntityID = CurrentEntity.EntityID
														foreach (XmlNode)
														{
															//trace(XmlNodeName)
															if (XmlNodeName == "MethodID")
															{
																foreach (XmlNode)
																{
																	CurrentMethod.MethodID = Value
																}
															}
															if (XmlNodeName == "MethodName")
															{
																foreach (XmlNode)
																{
																	CurrentMethod.MethodName = Value
																}
															}
															if (XmlNodeName == "MethodTypeCode")
															{
																foreach (XmlNode)
																{
																	CurrentMethod.MethodTypeCode = Value
																}
															}
															if (XmlNodeName == "Description")
															{
																foreach (XmlNode)
																{
																	CurrentMethod.Description = Value
																}
															}
															if (XmlNodeName == "Tags")
															{
																foreach (XmlNode)
																{
																	CurrentMethod.Tags = Value
																}
															}
														}
														add(CurrentMethod)
														foreach (XmlNode)
														{
															if (XmlNodeName == "MethodRelationshipList")
															{
																foreach (XmlNode)
																{
																	if (XmlNodeName == "MethodRelationship")
																	{
																		// add the method relationship from the xml
																		CurrentMethodRelationship = New()
																		CurrentMethodRelationship.MethodID = CurrentMethod.MethodID
																		foreach (XmlNode)
																		{
																			// trace(XmlNodeName)
																			if (XmlNodeName == "RelationshipID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentMethodRelationship.RelationshipID = Value
																				}
																			}
																			if (XmlNodeName == "Order")
																			{
																				foreach (XmlNode)
																				{
																					CurrentMethodRelationship.Order = Value
																				}
																			}
																			if (XmlNodeName == "Description")
																			{
																				foreach (XmlNode)
																				{
																					CurrentMethodRelationship.Description = Value
																				}
																			}
																			if (XmlNodeName == "Tags")
																			{
																				foreach (XmlNode)
																				{
																					CurrentMethodRelationship.Tags = Value
																				}
																			}
																		}
																		add(CurrentMethodRelationship)
																	}
																}
															}
															if (XmlNodeName == "ParameterList")
															{
																foreach (XmlNode)
																{
																	if (XmlNodeName == "Parameter")
																	{
																		// add the parameter from the xml
																		CurrentParameter = New()
																		CurrentParameter.MethodID = CurrentMethod.MethodID
																		foreach (XmlNode)
																		{
																			// trace(XmlNodeName)
																			if (XmlNodeName == "ParameterID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentParameter.ParameterID = Value
																				}
																			}
																			if (XmlNodeName == "ReferencedPropertyID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentParameter.ReferencedPropertyID = Value
																				}
																			}
																			if (XmlNodeName == "ReferencedEntityID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentParameter.ReferencedEntityID = Value
																				}
																			}
																			if (XmlNodeName == "ParameterName")
																			{
																				foreach (XmlNode)
																				{
																					CurrentParameter.ParameterName = Value
																				}
																			}
																			if (XmlNodeName == "Order")
																			{
																				foreach (XmlNode)
																				{
																					CurrentParameter.Order = Value
																				}
																			}
																			if (XmlNodeName == "Description")
																			{
																				foreach (XmlNode)
																				{
																					CurrentParameter.Description = Value
																				}
																			}
																			if (XmlNodeName == "Tags")
																			{
																				foreach (XmlNode)
																				{
																					CurrentParameter.Tags = Value
																				}
																			}
																		}
																		add(CurrentParameter)
																	}
																}
															}
														}
													}
												}
											}
											if (XmlNodeName == "IndexList")
											{
												foreach (XmlNode)
												{
													if (XmlNodeName == "Index")
													{
														// add the index from the xml
														CurrentIndex = New()
														CurrentIndex.EntityID = CurrentEntity.EntityID
														foreach (XmlNode)
														{
															// trace(XmlNodeName)
															if (XmlNodeName == "IndexID")
															{
																foreach (XmlNode)
																{
																	CurrentIndex.IndexID = Value
																}
															}
															if (XmlNodeName == "IndexName")
															{
																foreach (XmlNode)
																{
																	CurrentIndex.IndexName = Value
																}
															}
															if (XmlNodeName == "IsPrimaryKeyIndex")
															{
																foreach (XmlNode)
																{
																	CurrentIndex.IsPrimaryKeyIndex = Value
																}
															}
															if (XmlNodeName == "IsUniqueIndex")
															{
																foreach (XmlNode)
																{
																	CurrentIndex.IsUniqueIndex = Value
																}
															}
															if (XmlNodeName == "Description")
															{
																foreach (XmlNode)
																{
																	CurrentIndex.Description = Value
																}
															}
															if (XmlNodeName == "Tags")
															{
																foreach (XmlNode)
																{
																	CurrentIndex.Tags = Value
																}
															}
														}
														add(CurrentIndex)
														foreach (XmlNode)
														{
															if (XmlNodeName == "IndexPropertyList")
															{
																foreach (XmlNode)
																{
																	if (XmlNodeName == "IndexProperty")
																	{
																		// add the index property from the xml
																		CurrentIndexProperty = New()
																		CurrentIndexProperty.IndexID = CurrentIndex.IndexID
																		foreach (XmlNode)
																		{
																			// trace(XmlNodeName)
																			if (XmlNodeName == "PropertyID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentIndexProperty.PropertyID = Value
																				}
																			}
																			if (XmlNodeName == "EntityID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentIndexProperty.EntityID = Value
																				}
																			}
																			if (XmlNodeName == "Order")
																			{
																				foreach (XmlNode)
																				{
																					CurrentIndexProperty.Order = Value
																				}
																			}
																			if (XmlNodeName == "Description")
																			{
																				foreach (XmlNode)
																				{
																					CurrentIndexProperty.Description = Value
																				}
																			}
																			if (XmlNodeName == "Tags")
																			{
																				foreach (XmlNode)
																				{
																					CurrentIndexProperty.Tags = Value
																				}
																			}
																		}
																		add(CurrentIndexProperty)
																	}
																}
															}
														}
													}
												}
											}
											if (XmlNodeName == "RelationshipList")
											{
												foreach (XmlNode)
												{
													if (XmlNodeName == "Relationship")
													{
														// add the relationship from the xml
														CurrentRelationship = New()
														CurrentRelationship.EntityID = CurrentEntity.EntityID
														foreach (XmlNode)
														{
															//trace(XmlNodeName)
															if (XmlNodeName == "RelationshipID")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.RelationshipID = Value
																}
															}
															if (XmlNodeName == "ReferencedEntityID")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.ReferencedEntityID = Value
																}
															}
															if (XmlNodeName == "RelationshipName")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.RelationshipName = Value
																}
															}
															if (XmlNodeName == "Description")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.Description = Value
																}
															}
															if (XmlNodeName == "Tags")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.Tags = Value
																}
															}
															if (XmlNodeName == "ItemsMin")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.ItemsMin = Value
																}
															}
															if (XmlNodeName == "ItemsMax")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.ItemsMax = Value
																}
															}
															if (XmlNodeName == "ReferencedItemsMin")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.ReferencedItemsMin = Value
																}
															}
															if (XmlNodeName == "ReferencedItemsMax")
															{
																foreach (XmlNode)
																{
																	CurrentRelationship.ReferencedItemsMax = Value
																}
															}
														}
														add(CurrentRelationship)
														foreach (XmlNode)
														{
															if (XmlNodeName == "RelationshipPropertyList")
															{
																foreach (XmlNode)
																{
																	if (XmlNodeName == "RelationshipProperty")
																	{
																		// add the index property from the xml
																		CurrentRelationshipProperty = New()
																		CurrentRelationshipProperty.RelationshipID = CurrentRelationship.RelationshipID
																		foreach (XmlNode)
																		{
																			// trace(XmlNodeName)
																			if (XmlNodeName == "PropertyID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentRelationshipProperty.PropertyID = Value
																				}
																			}
																			if (XmlNodeName == "ReferencedPropertyID")
																			{
																				foreach (XmlNode)
																				{
																					CurrentRelationshipProperty.ReferencedPropertyID = Value
																				}
																			}
																			if (XmlNodeName == "Order")
																			{
																				foreach (XmlNode)
																				{
																					CurrentRelationshipProperty.Order = Value
																				}
																			}
																			if (XmlNodeName == "Description")
																			{
																				foreach (XmlNode)
																				{
																					CurrentRelationshipProperty.Description = Value
																				}
																			}
																			if (XmlNodeName == "Tags")
																			{
																				foreach (XmlNode)
																				{
																					CurrentRelationshipProperty.Tags = Value
																				}
																			}
																		}
																		add(CurrentRelationshipProperty)
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
%%></OUTPUT>
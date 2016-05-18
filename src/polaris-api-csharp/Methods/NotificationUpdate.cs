﻿using System;
using System.Xml.Linq;

using Clc.Polaris.Api.Validation;
using Clc.Polaris.Api.Models;
using System.Net.Http;

namespace Clc.Polaris.Api
{
	public partial class PapiClient
	{
		/// <summary>
		/// Updates a phone notification.
		/// </summary>
		/// <summary>
		/// Currently only supports phone notifications; DeliveryOptionIDs 3, 4, and 5
		/// </summary>
		/// <param name="options">Contains all of the relevant parameters to process a NotificationUpdate.</param>
		/// <returns>An object containing the result of the NotificationUpdate.</returns>
		/// <seealso cref="NotificationUpdateParams"/>
		/// <seealso cref="NotificationUpdateResult"/>
		public PapiResponse<NotificationUpdateResult> NotificationUpdate(NotificationUpdateParams options)
		{
			Require.Argument("AccessToken", Token.AccessToken);
			Require.Argument("NotificationTypeID", options.NotificationTypeId);
			Require.Argument("NotificationStatusID", options.CallStatus);
			Require.Argument("DeliveryOptionID", options.DeliveryOptionId);
			Require.Argument("DeliveryString", options.DeliveryString);
			Require.Argument("Details", options.Details);
			Require.Argument("PatronID", options.PatronId);
			Require.Argument("ItemRecordID", options.ItemRecordId);

			var doc = new XDocument(
				new XElement("NotificationUpdateData",
				             new XElement("LogonBranchID", options.BranchId),
				             new XElement("LogonUserID", options.UserId),
				             new XElement("LogonWorkstationID", options.WorkstationId),
				             new XElement("NotificationStatusID", options.CallStatus),
				             new XElement("NotificationDeliveryDate", DateTime.Today.ToString("yyyy-MM-dd")),
				             new XElement("DeliveryOptionID", options.DeliveryOptionId),
				             new XElement("DeliveryString", options.DeliveryString),
				             new XElement("Details", options.Details),
				             new XElement("PatronID", options.PatronId),
				             new XElement("ItemRecordID", options.ItemRecordId)
					)
				);

            var url = $"PAPIService/REST/protected/v1/1033/100/1/{Token.AccessToken}/notification/{options.NotificationTypeId}";
			return Execute<NotificationUpdateResult>(HttpMethod.Put, url, Token.AccessSecret, doc.ToString());
		}
	}
}
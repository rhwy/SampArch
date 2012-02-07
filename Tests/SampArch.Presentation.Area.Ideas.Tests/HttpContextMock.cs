using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Rhino.Mocks;

namespace SampArch.Presentation.Area.Ideas.Tests
{
    public class HttpContextMock
    {
        private readonly HttpContextBase _contextBase;
        private readonly HttpRequestBase _requestBase;
        private readonly HttpResponseBase _responseBase;
        private readonly HttpSessionStateBase _sessionStateBase;
        private readonly HttpServerUtilityBase _serverUtilityBase;

        public HttpContextBase Context { get { return _contextBase; } }
        public HttpRequestBase Request { get { return _requestBase; } }
        public HttpResponseBase Response { get { return _responseBase; } }
        public HttpSessionStateBase Session { get { return _sessionStateBase; } }
        public HttpServerUtilityBase Server { get { return _serverUtilityBase; } }


        public HttpContextMock()
        {
            _contextBase = MockRepository.GenerateStub<HttpContextBase>();
            _requestBase = MockRepository.GenerateStub<HttpRequestBase>();
            _responseBase = MockRepository.GenerateStub<HttpResponseBase>();
            _sessionStateBase = MockRepository.GenerateStub<HttpSessionStateBase>();
            _serverUtilityBase = MockRepository.GenerateStub<HttpServerUtilityBase>();

            _contextBase.Stub(x => x.Request).Return(_requestBase);
            _contextBase.Stub(x => x.Response).Return(_responseBase);
            _contextBase.Stub(x => x.Session).Return(_sessionStateBase);
            _contextBase.Stub(x => x.Server).Return(_serverUtilityBase);
        }
    }
}

﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using PuppeteerSharp.Contrib.PageObjects;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public static class Fake
    {
        public static string Html => "<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>";
    }

    public class FakePageObject : PageObject
    {
        [Selector(".tweet")]
        public virtual Task<ElementHandle> SelectorForElementHandle { get; }

        [Selector("div")]
        public virtual Task<ElementHandle[]> SelectorForElementHandleArray { get; }

        [Selector(".retweets")]
        public virtual Task<FakeElementObject> SelectorForElementObject { get; }

        [XPath("//div")]
        public virtual Task<ElementHandle[]> XPathForElementHandleArray { get; }
    }

    public class FakeElementObject : ElementObject
    {
        [Selector(".tweet")]
        public virtual Task<ElementHandle> SelectorForElementHandle { get; }

        [Selector("div")]
        public virtual Task<ElementHandle[]> SelectorForElementHandleArray { get; }

        [Selector(".retweets")]
        public virtual Task<FakeElementObject> SelectorForElementObject { get; }

        [XPath("//div")]
        public virtual Task<ElementHandle[]> XPathForElementHandleArray { get; }
    }

    public class FakeInvocation : AbstractInvocation
    {
        public FakeInvocation(MethodInfo proxiedMethod, object proxy = null) : base(proxy, null, proxiedMethod, null)
        {
            TargetType = proxiedMethod.DeclaringType;
            InvocationTarget = proxy;
        }

        protected override void InvokeMethodOnTarget() => throw new NotImplementedException();

        public override object InvocationTarget { get; }
        public override Type TargetType { get; }
        public override MethodInfo MethodInvocationTarget { get; }
    }
}